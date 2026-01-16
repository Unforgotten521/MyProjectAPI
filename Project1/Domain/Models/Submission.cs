using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int AssignmentId { get; set; }

    public int StudentId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime? SubmittedAt { get; set; }

    public string? Status { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual User Student { get; set; } = null!;

    public virtual ICollection<SubmissionResult> SubmissionResults { get; set; } = new List<SubmissionResult>();
}
