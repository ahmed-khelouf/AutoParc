using System.Diagnostics;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.AspNetCore.Mvc;
using AutoParc.WebUI.Models;
using AutoParc.WebUI.ViewsModels.Entreprise;
using AutoParc.WebUI.ViewsModels.Vehicule;
using Microsoft.AspNetCore.Authorization;

namespace AutoParc.WebUI.Controllers;

//[Authorize(Roles = "Admin")]
public class VehiculeController : Controller
{
    private readonly IVehiculeDataSource vehiculeDataSource;
    
    public VehiculeController(IVehiculeDataSource vehiculeDataSource)
    {
        this.vehiculeDataSource = vehiculeDataSource;
    }

    //public IActionResult Index()
    //{
       
    //}
    
    [HttpGet]
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
}