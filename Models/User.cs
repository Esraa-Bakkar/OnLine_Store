using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace On_line_Store.Models;

public partial class User
{
    [Key]
    public int UId { get; set; }

    public string? UName { get; set; }

    public bool? Admin { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    
    public string? Phone { get; set; }

    public int UidNew { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
