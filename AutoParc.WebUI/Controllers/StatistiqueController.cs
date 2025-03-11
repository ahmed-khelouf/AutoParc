using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.AspNetCore.Mvc;
using AutoParc.WebUI.ViewsModels.Entreprise;
using AutoParc.WebUI.ViewsModels.Vehicule;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AutoParc.WebUI.ViewsModels.Statistique;

namespace AutoParc.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatistiqueController : Controller
    {
        private readonly IEntrepriseDataSource entrepriseDataSource;
        private readonly IVehiculeDataSource vehiculeDataSource;

        public StatistiqueController(IEntrepriseDataSource entrepriseDataSource, IVehiculeDataSource vehiculeDataSource)
        {
            this.entrepriseDataSource = entrepriseDataSource;
            this.vehiculeDataSource = vehiculeDataSource;
        }
        
        public IActionResult Index()
        {
            var stats = GetGlobalStatistiques();
            
            var viewModel = new StatistiqueViewModel
            {
                PageTitle = "Statistiques Globales",
                Stats = stats
            };

            return View(viewModel);
        }
        
        private StatistiqueModel GetGlobalStatistiques()
        {
            var entreprises = entrepriseDataSource.GetEntreprises();
            var totalEntreprises = entreprises.Count();
            var activeEntreprises = entreprises.Count(e => e.ContratActif);
            var inactiveEntreprises = totalEntreprises - activeEntreprises;
            
            var totalVéhicules = vehiculeDataSource.GetVehicules().Count();

            var vehiculesDispo = 0;
            var vehiculesPasDispo = 0;  
            foreach (var vehicule in vehiculeDataSource.GetVehicules())
            {
                if (vehicule.Disponibilite)
                {
                    vehiculesDispo++;
                }
                else
                {
                    vehiculesPasDispo++;
                }
            }
            return new StatistiqueModel
            {
                TotalEntreprises = totalEntreprises,
                ActiveEntreprises = activeEntreprises,
                InactiveEntreprises = inactiveEntreprises,
                TotalVéhicules = totalVéhicules,
                VehiculesDisponible = vehiculesDispo,
                VehiculesPasDispo = vehiculesPasDispo
            };
        }
    }
}
