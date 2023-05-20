using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Rabatt
{
    public int Idrabatt { get; set; }

    public decimal? Prozent { get; set; }

    public DateTime? GueltigkeitVon { get; set; }

    public DateTime? GueltigkeitBis { get; set; }

    public virtual ICollection<Bestellungsposition> Bestellungspositions { get; set; } = new List<Bestellungsposition>();
}
