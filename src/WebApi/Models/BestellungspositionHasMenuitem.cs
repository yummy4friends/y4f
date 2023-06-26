using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class BestellungspositionHasMenuitem
{
	public int? Bestellungsposition_IDBestellung { get; set; }

	public int? MenuItem_IDMenuItem { get; set; }
}
