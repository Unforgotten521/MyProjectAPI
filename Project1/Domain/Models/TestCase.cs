using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TestCase
{
    public int TestCaseId { get; set; }

    public int AssignmentId { get; set; }

    public string? InputData { get; set; }

    public string? ExpectedOutput { get; set; }

    public bool? IsHidden { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual ICollection<SubmissionResult> SubmissionResults { get; set; } = new List<SubmissionResult>();
}
