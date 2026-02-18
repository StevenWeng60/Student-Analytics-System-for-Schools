using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using StudentAnalytics.Enums;
namespace StudentAnalytics.DTOs
{
    public record CreateStudentDto
    {
        [Required]
        public int SchoolId { get; init; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; init; }

        [StringLength(100)]
        public string? MiddleName { get; init; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; init; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required GenderType Gender { get; init; } = GenderType.other;

        public DateOnly? DateOfBirth { get; init; }

        [Required]
        [Range(1, 12)]
        public ushort GradeLevel { get; init; }
    }

    public record UpdateStudentDto
    {
        public int? SchoolId { get; init; }

        [StringLength(100)]
        public string? FirstName { get; init; }

        [StringLength(100)]
        public string? MiddleName { get; init; }

        [StringLength(100)]
        public string? LastName { get; init; }

        public GenderType? Gender { get; init; }

        public DateOnly? DateOfBirth { get; init; }

        [Range(1, 12)]
        public ushort? GradeLevel { get; init; }
    }

    public record StudentResponseDto
    {
        public required int Id { get; init; }
        public required int SchoolId { get; init; }
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }
        public required GenderType Gender { get; init; }
        public DateOnly? DateOfBirth { get; init; }
        public required ushort GradeLevel { get; init; }
        public string? SchoolName { get; init; }
    }
}