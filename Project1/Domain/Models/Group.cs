using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
