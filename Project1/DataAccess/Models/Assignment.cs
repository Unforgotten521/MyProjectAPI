using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int TypeId { get; set; }

    public int? LanguageId { get; set; }

    public int MaxPoints { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ProgrammingLanguage? Language { get; set; }

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<TestCase> TestCases { get; set; } = new List<TestCase>();

    public virtual AssignmentType Type { get; set; } = null!;
}
