using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Menuitemkategorie
{
    public int IdmenuItemKategorie { get; set; }

    public string? Bezeichnung { get; set; }

    public int MenuItemUeberkategorieIdmenuItemUeberkategorie { get; set; }

    public virtual Menuitemueberkategorie MenuItemUeberkategorieIdmenuItemUeberkategorieNavigation { get; set; } = null!;

    public virtual ICollection<Menuitem> Menuitems { get; set; } = new List<Menuitem>();
}
