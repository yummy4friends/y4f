namespace WebApi.Models
{
	public class MenuitemHasAllergie
	{
		// navigation references Menuitem
		public int? MenuItem_IDMenuItem { get; set; }

		// navigation references Allergie
		public int? Allergie_IDAllergie { get; set; }
	}
}
