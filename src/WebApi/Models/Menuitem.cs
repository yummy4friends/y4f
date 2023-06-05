using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Menuitem
{
    public int IdmenuItem { get; set; }

    public string? Bezeichnung { get; set; }

    public string? Zusatzinformation { get; set; }

    public decimal? Preis { get; set; }

    public int MenuItemKategorieIdmenuItemKategorie { get; set; }

    public virtual Menuitemkategorie MenuItemKategorieIdmenuItemKategorieNavigation { get; set; } = null!;

    public virtual ICollection<Allergie> AllergieIdallergies { get; set; } = new List<Allergie>();

    public virtual ICollection<Bestellungsposition> BestellungspositionIdbestellungs { get; set; } = new List<Bestellungsposition>();
}
