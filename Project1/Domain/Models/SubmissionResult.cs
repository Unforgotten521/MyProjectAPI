using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SubmissionResult
{
    public int ResultId { get; set; }

    public int SubmissionId { get; set; }

    public int? TestCaseId { get; set; }

    public bool? IsPassed { get; set; }

    public string? ActualOutput { get; set; }

    public string? ErrorMessage { get; set; }

    public int PointsAwarded { get; set; }

    public string? Feedback { get; set; }

    public DateTime? CheckedAt { get; set; }

    public int GradedBy { get; set; }

    public virtual User GradedByNavigation { get; set; } = null!;

    public virtual Submission Submission { get; set; } = null!;

    public virtual TestCase? TestCase { get; set; }
}
