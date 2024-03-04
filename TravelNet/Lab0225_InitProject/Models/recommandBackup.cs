using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class recommandBackup
{
    public string userId { get; set; } = null!;

    public string? gender { get; set; }

    public string? age { get; set; }

    public string? likeWeather { get; set; }

    public string? interest1 { get; set; }

    public string? interest2 { get; set; }

    public string? interest3 { get; set; }

    public string? likeLocation { get; set; }
}
