using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAnalytics.Context;
using StudentAnalytics.Models;
using StudentAnalytics.DTOs;

namespace StudentAnalytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentAnalyticsSystemContext _context;

        public StudentsController(StudentAnalyticsSystemContext context)
        {
            _context = context;
        }

        // Action methods for CRUD operations will go here
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.School)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Gender = s.GenderEnum,
                    DateOfBirth = s.DateOfBirth,
                    GradeLevel = s.GradeLevel,
                    SchoolName = s.School != null ? s.School.Name : null,
                })
                .ToListAsync();

            return Ok(students);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.School)
                .Where(s => s.Id == id)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Gender = s.GenderEnum,
                    DateOfBirth = s.DateOfBirth,
                    GradeLevel = s.GradeLevel,
                    SchoolName = s.School != null ? s.School.Name : null,
                })
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> CreateStudent(CreateStudentDto createDto)
        {
            // Validate SchoolId
            var school = await _context.Schools.FindAsync(createDto.SchoolId);
            if (school == null)
            {
                return BadRequest(new { message = "Invalid SchoolId" });
            }

            var student = new Student
            {
                SchoolId = createDto.SchoolId,
                FirstName = createDto.FirstName,
                MiddleName = createDto.MiddleName,
                LastName = createDto.LastName,
                Gender = createDto.Gender.ToString().ToLower(),
                DateOfBirth = createDto.DateOfBirth,
                GradeLevel = createDto.GradeLevel,
                School = school
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var responseDto = await _context.Students
                .Include(s => s.School)
                .Where(s => s.Id == student.Id)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Gender = s.GenderEnum,
                    DateOfBirth = s.DateOfBirth,
                    GradeLevel = s.GradeLevel,
                    SchoolName = s.School != null ? s.School.Name : null
                })
                .FirstAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentResponseDto>> UpdateStudent(int id, UpdateStudentDto updateDto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            if (updateDto.SchoolId.HasValue)
            {
                var school = await _context.Schools.FindAsync(updateDto.SchoolId.Value);

                if (school == null)
                {
                    return BadRequest(new { message = "Invalid SchoolId" });
                }

                student.SchoolId = updateDto.SchoolId.Value;
                student.School = school;
            }

            if (updateDto.FirstName != null) student.FirstName = updateDto.FirstName;
            if (updateDto.MiddleName != null) student.MiddleName = updateDto.MiddleName;
            if (updateDto.LastName != null) student.LastName = updateDto.LastName;
            if (updateDto.Gender != null) student.Gender = updateDto.Gender.Value.ToString().ToLower();
            if (updateDto.DateOfBirth.HasValue) student.DateOfBirth = updateDto.DateOfBirth.Value;
            if (updateDto.GradeLevel.HasValue) student.GradeLevel = updateDto.GradeLevel.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Students.AnyAsync(s => s.Id == id))
                {
                    return NotFound(new { message = "Student not found" });
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("school/{schoolId}")]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudentsBySchool(int schoolId)
        {
            var students = await _context.Students
                .Include(s => s.School)
                .Where(s => s.SchoolId == schoolId)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    SchoolId = s.SchoolId,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Gender = s.GenderEnum,
                    DateOfBirth = s.DateOfBirth,
                    GradeLevel = s.GradeLevel,
                    SchoolName = s.School != null ? s.School.Name : null
                })
                .ToListAsync();

            return Ok(students);
        }
    }
}