using Agl.Model;
using Agl.Mvc.Ui.Models;
using Agl.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agl.Mvc.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetOwnerService _petOwnerService;

        public HomeController(IPetOwnerService petOwnerService)
        {
            _petOwnerService = petOwnerService;
        }

        public ActionResult Index()
        {           
            var owners = _petOwnerService.GetPetOwner();
            var orderedPets = _petOwnerService.GetGroupedAndSortedPetOwner(PetType.Cat, owners);
            var viewModel = new HomeViewModel(orderedPets);

            return View(viewModel);
        }
        
    }
}