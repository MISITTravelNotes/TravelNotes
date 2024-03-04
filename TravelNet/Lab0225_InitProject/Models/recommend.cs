using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class recommend
{
    public int LabelId { get; set; }

    public int? UserId { get; set; }

    public string? Gender { get; set; }

    public string? Weather { get; set; }

    public string? Interest { get; set; }

    public string? Interest2 { get; set; }

    public string? Interest3 { get; set; }

    public string? Location { get; set; }
}
