using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Group? Group { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SubmissionResult> SubmissionResults { get; set; } = new List<SubmissionResult>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
