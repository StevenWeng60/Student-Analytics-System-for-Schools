using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using StudentAnalytics.Enums;
namespace StudentAnalytics.DTOs
{
    public record CreateClassDto
    {
        [Required]
        public int SchoolId { get; init; }
        [Required]
        public int TeacherId { get; init; }
        [Required]
        [StringLength(100)]
        public required string ClassName { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required SubjectType Subject { get; init; }
        [Required]
        public required ushort Period { get; init; }
        [Required]
        public required DateOnly StartDate { get; init; }
        [Required]
        public required DateOnly EndDate { get; init; }
    }

    public record UpdateClassDto
    {
        public int? SchoolId { get; init; }
        public int? TeacherId { get; init; }
        [StringLength(100)]
        public string? ClassName { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubjectType? Subject { get; init; }
        public ushort? Period { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
    }

    public record ClassResponseDto
    {
        public required int Id { get; init; }
        public required int SchoolId { get; init; }
        public required int TeacherId { get; init; }
        public required string ClassName { get; init; }
        public required SubjectType Subject { get; init; }
        public required ushort Period { get; init; }
        public required DateOnly StartDate { get; init; }
        public required DateOnly EndDate { get; init; }
    }
}