using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Submission
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public long AssignmentId { get; set; }

    public ushort? Grade { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual Enrollment Enrollment { get; set; } = null!;
}
