using System;
using System.Collections.Generic;

namespace On_line_Store.Models;

public partial class Review
{
    public int RId { get; set; }

    public int? UId { get; set; }

    public int? PId { get; set; }

    public decimal? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Product? PIdNavigation { get; set; }

    public virtual User? UIdNavigation { get; set; }
}
