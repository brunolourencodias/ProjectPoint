using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Onecore_Web.Controllers
{
    public class PainelController : Controller
    {
        #region Routes

        [Route("Painel/Painel")]
        public IActionResult Index()
        {
            return View("Painel");
        }

        public IActionResult Marcation()
        {
            return View("Services/Marcation");
        }

        
        public IActionResult Vacation()
        {
            return View("Services/Vacation");
        }

        #endregion

    }
}