using System.Diagnostics;
using System.Security.Claims;
using AutoParc.DataSource;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.AspNetCore.Mvc;
using AutoParc.WebUI.Models;
using AutoParc.WebUI.ViewsModels.Entreprise;
using AutoParc.WebUI.ViewsModels.Vehicule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoParc.WebUI.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly IVehiculeDataSource vehiculeDataSource;
        private readonly IEntrepriseDataSource entrepriseDataSource;
        private readonly ILogger<HomeController> _logger;

        public VehiculeController(ILogger<HomeController> logger, IVehiculeDataSource vehiculeDataSource, IEntrepriseDataSource entrepriseDataSource)
        { 
            this.vehiculeDataSource = vehiculeDataSource;
            this.entrepriseDataSource = entrepriseDataSource;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetVehicule(int? IdEntreprise = null)
        {
            var viewModel = new GetVehiculeByEntrepriseViewModel
            {
                PageTitle = "Véhicules de l'entreprise"
            };

            if (IdEntreprise.HasValue)
            {
                List<VehiculeModel> vehicules = vehiculeDataSource.GetVehiculeByEntreprise(IdEntreprise.Value);

                if (vehicules != null && vehicules.Any())
                {
                    viewModel.VehiculeToEntreprise = VehiculeViewModel.FromVehiculeModel(vehicules);
                }
            }

            return View(viewModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEdit(int? id = null)
        {
            AddOrEditVehiculeViewModel addOrEditVehiculeViewModel = new AddOrEditVehiculeViewModel();
            
            if (id.HasValue)
            {
                VehiculeModel? v = vehiculeDataSource.GetVehiculeById(id.Value);

                if (v != null)
                {
                    addOrEditVehiculeViewModel.VehiculeToAddOrEdit = VehiculeViewModel.FromVehiculeModel(v);
                    addOrEditVehiculeViewModel.EntrepriseId = v.EntrepriseId;
                }
            }
            
            addOrEditVehiculeViewModel.EntreprisesAvailable = getEntrepriseSelectListItems();
            return View(addOrEditVehiculeViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEdit(AddOrEditVehiculeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.EntreprisesAvailable = getEntrepriseSelectListItems();  
                
                return View(model);
              
            }
            VehiculeModel vehiculeModel = model.VehiculeToAddOrEdit.ToVehiculeModel(model.EntrepriseId);
            vehiculeDataSource.AddOrUpdateVehicule(vehiculeModel);
        
            return RedirectToAction("Index", "Entreprise");

        }
        
        [HttpGet]
        [Authorize]
        public IActionResult GetVehiculeByEntrepriseForUser()
        {
            var entrepriseId = User.FindFirstValue("EntrepriseId");
            //_logger.LogInformation("AHMMEDDD"+entrepriseId);
            if (entrepriseId != null)
            {
                var idEntreprise = int.Parse(entrepriseId); 
                var viewModel = new GetVehiculeByEntrepriseViewModel
                {
                    PageTitle = "Véhicules de votre entreprise"
                };

                List<VehiculeModel> vehicules = vehiculeDataSource.GetVehiculeByEntreprise(idEntreprise);

                if (vehicules != null && vehicules.Any())
                {
                    viewModel.VehiculeToEntreprise = VehiculeViewModel.FromVehiculeModel(vehicules);
                }
              
                return View(viewModel);
            }
                return View();
        }


        private List<SelectListItem> getEntrepriseSelectListItems()
        {
            IEnumerable<EntrepriseModel> entreprises = entrepriseDataSource.GetEntreprises();

            var entrepriseSelectList = entreprises.Select(entreprise => new SelectListItem
            {
                Value = entreprise.Id.ToString(),
                Text = entreprise.Nom
            }).ToList();

            return entrepriseSelectList;
        }
    }
}