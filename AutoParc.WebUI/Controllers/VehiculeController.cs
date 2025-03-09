using System.Diagnostics;
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
    //[Authorize(Roles = "Admin")]
    public class VehiculeController : Controller
    {
        private readonly IVehiculeDataSource vehiculeDataSource;
        private readonly IEntrepriseDataSource entrepriseDataSource;

        public VehiculeController(IVehiculeDataSource vehiculeDataSource, IEntrepriseDataSource entrepriseDataSource)
        {
            this.vehiculeDataSource = vehiculeDataSource;
            this.entrepriseDataSource = entrepriseDataSource;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetVehicule(int? IdEntreprise = null)
        {
            var viewModel = new GetVehiculeByEntrepriseViewModel
            {
                PageTitle = "Véhicules associés à l'entreprise"
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
