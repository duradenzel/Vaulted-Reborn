using Microsoft.AspNetCore.Mvc;

namespace Vaulted_Reborn.Controllers
{
	public class CharacterSheetController : Controller
	{
		public IActionResult CharacterSheet()
		{
			return View("CharacterSheet");
		}
	}
}
