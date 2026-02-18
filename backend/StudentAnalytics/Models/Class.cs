using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Class
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public int TeacherId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Subject { get; set; }

    public ushort Period { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual School School { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
