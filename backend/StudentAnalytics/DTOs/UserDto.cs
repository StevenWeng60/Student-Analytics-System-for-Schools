using System.ComponentModel.DataAnnotations;
using StudentAnalytics.Enums;

namespace StudentAnalytics.DTOs
{
    public record CreateUserDto
    {
        [Required]
        public required int SchoolId { get; init; }
        [Required]
        [StringLength(100)]
        public required string Username { get; init; }
        [Required]
        [StringLength(255)]
        public required string Password { get; init; }
        [Required]
        public required UserType UserType { get; init; }
    };

    public record UpdateUserDto
    {
            public int? SchoolId { get; init; }
            [StringLength(100)]
            public string? Username { get; init; }
            [StringLength(255)]
            public string? Password { get; init; }
            public UserType? UserType { get; init; }
    }

    public record UserResponseDto
    {
        public required int Id { get; init; }
        public required int SchoolId { get; init; }
        public required string Username { get; init; }
        public required UserType UserType { get; init; }
    }

}