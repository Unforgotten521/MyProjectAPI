using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AssignmentType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
