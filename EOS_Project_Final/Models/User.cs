using System;
using System.Collections.Generic;

namespace EOS_Project_Final.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RoldId { get; set; }
}
