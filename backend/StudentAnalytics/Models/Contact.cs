using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class Contact
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
