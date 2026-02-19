using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAnalytics.Context;
using StudentAnalytics.Models;
using StudentAnalytics.DTOs;

namespace StudentAnalytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly StudentAnalyticsSystemContext _context;

        public TeacherController(StudentAnalyticsSystemContext context)
        {
            _context = context;
        }

        // Action methods for CRUD operations will go here
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherResponseDto>>> GetTeachers()
        {
            var teachers = await _context.Teachers
                .Include(t => t.School)
                .Include(t => t.User)
                .Select(t => new TeacherResponseDto
                {
                    Id = t.Id,
                    SchoolId = t.SchoolId,
                    UserId = t.UserId,
                    FirstName = t.FirstName,
                    MiddleName = t.MiddleName,
                    LastName = t.LastName,
                    HireDate = t.HireDate,
                    EmailAddress = t.EmailAddress,
                    PhoneNumber = t.PhoneNumber,
                })
                .ToListAsync();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherResponseDto>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers
                .Include(t => t.School)
                .Include(t => t.User)
                .Where(t => t.Id == id)
                .Select(t => new TeacherResponseDto
                {
                    Id = t.Id,
                    SchoolId = t.SchoolId,
                    UserId = t.UserId,
                    FirstName = t.FirstName,
                    MiddleName = t.MiddleName,
                    LastName = t.LastName,
                    HireDate = t.HireDate,
                    EmailAddress = t.EmailAddress,
                    PhoneNumber = t.PhoneNumber,
                })
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found" });
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherResponseDto>> CreateTeacher(CreateTeacherDto createDto)
        {
            var teacher = new Teacher
            {
                SchoolId = createDto.SchoolId,
                UserId = createDto.UserId,
                FirstName = createDto.FirstName,
                MiddleName = createDto.MiddleName,
                LastName = createDto.LastName,
                HireDate = createDto.HireDate,
                EmailAddress = createDto.EmailAddress,
                PhoneNumber = createDto.PhoneNumber,
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            var responseDto = new TeacherResponseDto
            {
                Id = teacher.Id,
                SchoolId = teacher.SchoolId,
                UserId = teacher.UserId,
                FirstName = teacher.FirstName,
                MiddleName = teacher.MiddleName,
                LastName = teacher.LastName,
                HireDate = teacher.HireDate,
                EmailAddress = teacher.EmailAddress,
                PhoneNumber = teacher.PhoneNumber,
            };

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherResponseDto>> UpdateTeacher(int id, UpdateTeacherDto updateDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found" });
            }

            if (updateDto.SchoolId != null) teacher.SchoolId = updateDto.SchoolId.Value;
            if (updateDto.UserId != null) teacher.UserId = updateDto.UserId.Value;
            if (updateDto.FirstName != null) teacher.FirstName = updateDto.FirstName;
            if (updateDto.MiddleName != null) teacher.MiddleName = updateDto.MiddleName;
            if (updateDto.LastName != null) teacher.LastName = updateDto.LastName;
            if (updateDto.HireDate != null) teacher.HireDate = updateDto.HireDate.Value;
            if (updateDto.EmailAddress != null) teacher.EmailAddress = updateDto.EmailAddress;
            if (updateDto.PhoneNumber != null) teacher.PhoneNumber = updateDto.PhoneNumber;

            await _context.SaveChangesAsync();

            var responseDto = new TeacherResponseDto
            {
                Id = teacher.Id,
                SchoolId = teacher.SchoolId,
                UserId = teacher.UserId,
                FirstName = teacher.FirstName,
                MiddleName = teacher.MiddleName,
                LastName = teacher.LastName,
                HireDate = teacher.HireDate,
                EmailAddress = teacher.EmailAddress,
                PhoneNumber = teacher.PhoneNumber,
            };

            return Ok(responseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found" });
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}