using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoParc.WebUI.ViewsModels.Employee;

public class UpdateVehiculeViewModel
{
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Vehicules { get; set; }
        public int SelectedEmployeeId { get; set; }
        public int SelectedVehiculeId { get; set; }
}