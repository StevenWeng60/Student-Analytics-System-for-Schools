using System;
using System.Collections.Generic;

namespace StudentAnalytics.Models;

public partial class User
{
    public int Id { get; set; }

    public int? SchoolId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual School? School { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
