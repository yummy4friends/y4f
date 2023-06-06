using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Allergie
{
    public int Idallergie { get; set; }

    public string? Beschreibung { get; set; }

    public virtual ICollection<Menuitem> MenuItemIdmenuItems { get; set; } = new List<Menuitem>();
}
