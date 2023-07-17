using System;
using System.Collections.Generic;

namespace EOS_Project_Final.Models;

public partial class Quiz
{
    public string Id { get; set; } = null!;

    public string? Question { get; set; }

    public string? Anwser { get; set; }

    public int? TypeId { get; set; }

    public virtual Type? Type { get; set; }
}
