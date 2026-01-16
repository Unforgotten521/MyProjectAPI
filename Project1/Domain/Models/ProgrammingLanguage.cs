using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProgrammingLanguage
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
