using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Menuitemueberkategorie
{
    public int IdmenuItemUeberkategorie { get; set; }

    public string? Bezeichnung { get; set; }

    public virtual ICollection<Menuitemkategorie> Menuitemkategories { get; set; } = new List<Menuitemkategorie>();
}
