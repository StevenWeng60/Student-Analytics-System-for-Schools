using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SchoolId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual School School { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
