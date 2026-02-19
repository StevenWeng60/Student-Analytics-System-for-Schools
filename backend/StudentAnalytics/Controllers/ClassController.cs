using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAnalytics.DTOs;
using System.Collections.Generic;
using StudentAnalytics.Context;
using StudentAnalytics.Models;

namespace StudentAnalytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly StudentAnalyticsSystemContext _context;

        public ClassController(StudentAnalyticsSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GetAllClasses()
        {
            var classes = await _context.Classes
                .Include(c => c.School)
                .Include(c => c.Teacher)
                .Select(c => new ClassResponseDto
                {
                    Id = c.Id,
                    SchoolId = c.SchoolId,
                    TeacherId = c.TeacherId,
                    ClassName = c.ClassName,
                    Subject = c.SubjectTypeEnum,
                    Period = c.Period,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .ToListAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassResponseDto>> GetClassById(int id)
        {
            var classDto = await _context.Classes
                .Where(c => c.Id == id)
                .Select(c => new ClassResponseDto
                {
                    Id = c.Id,
                    SchoolId = c.SchoolId,
                    TeacherId = c.TeacherId,
                    ClassName = c.ClassName,
                    Subject = c.SubjectTypeEnum,
                    Period = c.Period,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .FirstOrDefaultAsync();

            if (classDto == null)
                return NotFound();

            return Ok(classDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClassResponseDto>> CreateClass(CreateClassDto createDto)
        {
            var newClass = new Class
            {
                SchoolId = createDto.SchoolId,
                TeacherId = createDto.TeacherId,
                ClassName = createDto.ClassName,
                Subject = createDto.Subject.ToString().ToLower(),
                Period = createDto.Period,
                StartDate = createDto.StartDate,
                EndDate = createDto.EndDate,
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();

            var createdClass = await _context.Classes
                .Where(c => c.Id == newClass.Id)
                .Select(c => new ClassResponseDto
                {
                    Id = c.Id,
                    SchoolId = c.SchoolId,
                    TeacherId = c.TeacherId,
                    ClassName = c.ClassName,
                    Subject = c.SubjectTypeEnum,
                    Period = c.Period,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .FirstOrDefaultAsync();

            return CreatedAtAction(nameof(GetClassById), new { id = newClass.Id }, createdClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, UpdateClassDto updateDto)
        {
            var classes = await _context.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound(new { message = "Class not found" });
            }

            if (updateDto.SchoolId != null) classes.SchoolId = updateDto.SchoolId.Value;
            if (updateDto.TeacherId != null) classes.TeacherId = updateDto.TeacherId.Value;
            if (updateDto.ClassName != null) classes.ClassName = updateDto.ClassName;
            if (updateDto.Subject != null) classes.Subject = updateDto.Subject.Value.ToString().ToLower();
            if (updateDto.Period != null) classes.Period = updateDto.Period.Value;
            if (updateDto.StartDate != null) classes.StartDate = updateDto.StartDate.Value;
            if (updateDto.EndDate != null) classes.EndDate = updateDto.EndDate.Value;

            await _context.SaveChangesAsync();

            var response = await _context.Classes
                .Where(c => c.Id == classes.Id)
                .Select(c => new ClassResponseDto
                {
                    Id = c.Id,
                    SchoolId = c.SchoolId,
                    TeacherId = c.TeacherId,
                    ClassName = c.ClassName,
                    Subject = c.SubjectTypeEnum,
                    Period = c.Period,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .FirstOrDefaultAsync();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classes = await _context.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound(new { message = "Class not found" });
            }

            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}