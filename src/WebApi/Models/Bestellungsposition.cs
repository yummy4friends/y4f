using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Bestellungsposition
{
	public int Idbestellung { get; set; }

	public int? Menge { get; set; }

	public DateTime? Datum { get; set; }

	public int KundeIdkunde { get; set; }

	public int? RabattIdrabatt { get; set; }

	public virtual Kunde? KundeIdkundeNavigation { get; set; } = null!;

	public virtual Rabatt? RabattIdrabattNavigation { get; set; } = null!;

	public virtual ICollection<Menuitem>? MenuItemIdmenuItems { get; set; } = new List<Menuitem>();
}
