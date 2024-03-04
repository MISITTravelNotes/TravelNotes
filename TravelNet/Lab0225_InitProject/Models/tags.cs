using System;
using System.Collections.Generic;

namespace Lab0225_InitProject.Models;

public partial class tags
{
    public int LabelId { get; set; }

    public int? ArticleId { get; set; }

    public string LabelName { get; set; } = null!;

    public string? LabelDescription { get; set; }

    public virtual article? Article { get; set; }
}
