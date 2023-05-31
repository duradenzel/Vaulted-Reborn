using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Vaulted_Reborn.ViewModels;
using VaultedBLL;
using VaultedBLL.Models;
using VaultedDAL;
using VaultedDAL.NewFolder;

namespace Vaulted_Reborn.Controllers
{
	public class CharacterController : Controller
	{
		private readonly CharacterService _characterService;

		public CharacterController()
		{
			_characterService = new CharacterService();
		}

        public async Task<IActionResult> Index(int id)
        {
            Character character = await _characterService.GetCharacter(id != 0 ? id : 2);
			List<CharacterDropdownItems> charnames = await _characterService.GetCharacterNames(1);

			var viewModel = new CharacterViewModel(charnames, character);

            return View("Character", viewModel);
        }

        public async Task<Character> LoadCharacter(int id)
        {
            Character character = await _characterService.GetCharacter(id);
             return character;
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges([FromBody] Character model)
        {
            var character = await _characterService.GetCharacter(model.Id);

            character.Race = model.Race;
            character.Subclass = model.Subclass;
            character.Class = model.Class;
            character.Level = model.Level;
            character.MaxHP = model.MaxHP;
            character.HP = model.HP;
            character.AC = model.AC;
            character.Speed = model.Speed;
            character.Strength = model.Strength;
            character.Dexterity = model.Dexterity;
            character.Constitution = model.Constitution;
            character.Intelligence = model.Intelligence;
            character.Wisdom = model.Wisdom;
            character.Charisma = model.Charisma;

            await _characterService.SaveChanges(character);

            return Ok(character);
        }

        public IActionResult Creator()
        {
            return View();
        }

        public async Task<IActionResult> CharacterList()
        {
            List<Character> characters = await _characterService.GetCharacters(1);

            return View("CharacterList", characters);
        }

        public async Task<IActionResult> CreateCharacter(Character character)
        {
            await _characterService.CreateCharacter(character);

            return RedirectToAction("CharacterList");
        }

        public async Task<IActionResult> DeleteCharacter(int id)
        {
            await _characterService.DeleteCharacter(id);

            return Ok();

        }



    }
}
