using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using VaultedBLL;
using VaultedDAL;
using VaultedDAL.NewFolder;

namespace Vaulted_Reborn.Controllers
{
	public class Character : Controller
	{
		private readonly CharacterService _characterService;

		public Character()
		{
			_characterService = new CharacterService( new CharacterDAO());
		}

		public IActionResult Index() {
            CharacterDTO character = _characterService.GetCharacter(1);

            return View("Character", character); }

		
	}
}
