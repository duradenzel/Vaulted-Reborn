using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vaulted.Models;
using VaultedBLL;
using VaultedDAL;

namespace Vaulted_Reborn.Controllers
{
    public class SpellController : Controller
    {
        private readonly SpellService _spellService;

        public SpellController()
        {
            _spellService = new SpellService(new SpellApi());
        }

        public async Task<IActionResult> Index()
        {
            string jsondata = await _spellService.GetSpellList();
            SpellList spellList = JsonConvert.DeserializeObject<SpellList>(jsondata);
            if (spellList != null)
            {
                return View(spellList);
            }
            
            return View();
           
        }
    }
}
