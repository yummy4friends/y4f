using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Kunde
{
    public int Idkunde { get; set; }

    public string? Code { get; set; }

    public int? Treuepunkte { get; set; }

    public virtual ICollection<Bestellungsposition> Bestellungspositions { get; set; } = new List<Bestellungsposition>();
}
