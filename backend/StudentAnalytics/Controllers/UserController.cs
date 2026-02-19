using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAnalytics.Context;
using StudentAnalytics.Models;
using StudentAnalytics.DTOs;
using Microsoft.AspNetCore.Identity;

namespace StudentAnalytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly StudentAnalyticsSystemContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(StudentAnalyticsSystemContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // Action methods for CRUD operations will go here
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.School)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    SchoolId = u.SchoolId,
                    Username = u.Username,
                    UserType = u.UserTypeEnum,
                })
                .ToListAsync();

            return Ok(users);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.School)
                .Where(u => u.Id == id)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    SchoolId = u.SchoolId,
                    Username = u.Username,
                    UserType = u.UserTypeEnum,
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto createDto)
        {
            // Validate user doesn't exist
            bool userExists = await _context.Users
                .AnyAsync(u => u.Username == createDto.Username);

            if (userExists)
            {
                return BadRequest(new { message = "User with that username already exists" });
            }

            // Validate SchoolId
            var school = await _context.Schools.FindAsync(createDto.SchoolId);
            if (school == null)
            {
                return BadRequest(new { message = "Invalid SchoolId" });
            }

            var user = new User
            {
                SchoolId = createDto.SchoolId,
                Username = createDto.Username,
                UserType = createDto.UserType.ToString().ToLower(),
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, createDto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var responseDto = await _context.Users
                .Include(u => u.School)
                .Where(u => u.Id == user.Id)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    SchoolId = u.SchoolId,
                    Username = u.Username,
                    UserType = u.UserTypeEnum,
                })
                .FirstAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(int id, UpdateUserDto updateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            if (updateDto.Username != null) user.Username = updateDto.Username;
            if (updateDto.UserType != null) user.UserType = updateDto.UserType.Value.ToString().ToLower();
            if (updateDto.SchoolId != null) user.SchoolId = updateDto.SchoolId.Value;
            if (updateDto.Password != null) user.PasswordHash = _passwordHasher.HashPassword(user, updateDto.Password);

            await _context.SaveChangesAsync();

            var responseDto = await _context.Users
                .Include(u => u.School)
                .Where(u => u.Id == user.Id)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    SchoolId = u.SchoolId,
                    Username = u.Username,
                    UserType = u.UserTypeEnum,
                })
                .FirstAsync();

            return Ok(responseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("bySchool/{schoolId}")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsersBySchool(int schoolId)
        {
            var user = await _context.Users.FindAsync(schoolId);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var users = await _context.Users
                .Include(u => u.School)
                .Where(u => u.SchoolId == schoolId)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    SchoolId = u.SchoolId,
                    Username = u.Username,
                    UserType = u.UserTypeEnum,
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}