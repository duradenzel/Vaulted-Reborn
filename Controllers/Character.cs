using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using VaultedBLL;
using VaultedDAL;

namespace Vaulted_Reborn.Controllers
{
	public class Character : Controller
	{
		private readonly CharacterService _characterService;

		public Character()
		{
			_characterService = new CharacterService( new CharacterDAO());
		}

		public IActionResult Index()
		{
			return View("Character");
		}
	}
}
