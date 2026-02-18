using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Student
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public ushort GradeLevel { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual School School { get; set; } = null!;
}
