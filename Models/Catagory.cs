using System;
using System.Collections.Generic;

namespace On_line_Store.Models;

public partial class Catagory
{
    public int CId { get; set; }

    public string? Description { get; set; }

    public string? CName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
