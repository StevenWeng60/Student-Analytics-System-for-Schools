using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Attendance
{
    public long Id { get; set; }

    public int EnrollmentId { get; set; }

    public int TeacherId { get; set; }

    public string? Status { get; set; }

    public ushort Period { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
