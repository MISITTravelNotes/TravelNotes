using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class album
{
    public int AlbumId { get; set; }

    public int UserId { get; set; }

    public string AlbumName { get; set; } = null!;

    public DateOnly? CreateTime { get; set; }

    public virtual users User { get; set; } = null!;

    public virtual ICollection<photo> photo { get; set; } = new List<photo>();
}
