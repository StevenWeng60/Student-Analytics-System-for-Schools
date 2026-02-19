using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using StudentAnalytics.Enums;
namespace StudentAnalytics.DTOs
{
    public record CreateTeacherDto
    {
        [Required]
        public required int SchoolId { get; init; }
        [Required]
        public required int UserId { get; init; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; init; }

        [StringLength(100)]
        public string? MiddleName { get; init; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; init; }
        public required DateOnly HireDate { get; init; }
        [StringLength(255)]
        public string? EmailAddress { get; init; }
        [StringLength(20)]
        public string? PhoneNumber { get; init; }
    }

    public record UpdateTeacherDto
    {
        public int? SchoolId { get; init; }
        public int? UserId { get; init; }

        [StringLength(100)]
        public string? FirstName { get; init; }

        [StringLength(100)]
        public string? MiddleName { get; init; }

        [StringLength(100)]
        public string? LastName { get; init; }
        public DateOnly? HireDate { get; init; }
        [StringLength(255)]
        public string? EmailAddress { get; init; }
        [StringLength(20)]
        public string? PhoneNumber { get; init; }
    }

    public record TeacherResponseDto
    {
        public required int Id { get; init; }
        public required int SchoolId { get; init; }
        public required int UserId { get; init; }
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }
        public required DateOnly HireDate { get; init; }
        public string? EmailAddress { get; init; }
        public string? PhoneNumber { get; init; }
    }
}