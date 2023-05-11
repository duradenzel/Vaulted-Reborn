using Vaulted_Reborn.Controllers;
using VaultedBLL.Models;

namespace Vaulted_Reborn.ViewModels
{
    public class CharacterViewModel
    {

        public List<CharacterDropdownItems> CharacterNames { get; set; }
        public Character Character { get; set; }

        public CharacterViewModel(List<CharacterDropdownItems> characterNames, Character character)
        {
            CharacterNames = characterNames;
            Character = character;
        }
    }

}
