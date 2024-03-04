using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class users
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public string? Gender { get; set; }

    public string? Pwd { get; set; }

    public string? Nickname { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Introduction { get; set; }

    public string? Interest { get; set; }

    public string? Haedshot { get; set; }

    public string? SuperUser { get; set; }

    public virtual ICollection<album> album { get; set; } = new List<album>();

    public virtual ICollection<article> article { get; set; } = new List<article>();

    public virtual ICollection<messageBoard> messageBoard { get; set; } = new List<messageBoard>();
}
