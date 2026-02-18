using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Assignment
{
    public long Id { get; set; }

    public int ClassId { get; set; }

    public string? AssignmentType { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? DateAssigned { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
