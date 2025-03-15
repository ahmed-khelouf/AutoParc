using AutoParc.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoParc.WebUI.ViewsModels.Vehicule
{
    public class AddOrEditVehiculeViewModel
    {
        public string PageTitle { get; set; } = "Véhicule"; 
        public VehiculeViewModel VehiculeToAddOrEdit { get; set; }
        public int EntrepriseId { get; set; }
        public IList<SelectListItem> EntreprisesAvailable { get; set; }
    }
}