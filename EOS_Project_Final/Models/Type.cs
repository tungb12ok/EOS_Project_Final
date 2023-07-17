using System;
using System.Collections.Generic;

namespace EOS_Project_Final.Models;

public partial class Type
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
