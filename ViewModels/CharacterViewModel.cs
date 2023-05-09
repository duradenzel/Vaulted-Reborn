using Vaulted_Reborn.Controllers;
using VaultedBLL.Models;

namespace Vaulted_Reborn.ViewModels
{
    public class CharacterViewModel
    {

        public List<CharacterDropdownItemsModel> CharacterNames { get; set; }
        public CharacterModel Character { get; set; }

        public CharacterViewModel(List<CharacterDropdownItemsModel> characterNames, CharacterModel character)
        {
            CharacterNames = characterNames;
            Character = character;
        }
    }

}
