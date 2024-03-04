using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class messageBoard
{
    public int MessageId { get; set; }

    public int ArticleId { get; set; }

    public int? UserId { get; set; }

    public string? Contents { get; set; }

    public DateOnly? MessageTime { get; set; }

    public virtual article Article { get; set; } = null!;

    public virtual users? User { get; set; }
}
