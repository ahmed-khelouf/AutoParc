
using System.Security.Claims;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using AutoParc.WebUI.ViewsModels.Employee;
using AutoParc.WebUI.ViewsModels.Vehicule;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AutoParc.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDataSource employeeDataSource;
        private readonly ILogger<HomeController> _logger;
        private readonly IVehiculeDataSource vehiculeDataSource;

        public EmployeeController(ILogger<HomeController> logger, IEmployeeDataSource employeeDataSource,
            IVehiculeDataSource vehiculeDataSource)
        {
            this.employeeDataSource = employeeDataSource;
            _logger = logger;
            this.vehiculeDataSource = vehiculeDataSource;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetEmployeeByEntrepriseForUser()
        {
            var entrepriseId = User.FindFirstValue("EntrepriseId");
            if (entrepriseId != null)
            {
                var idEntreprise = int.Parse(entrepriseId);
                var viewModel = new GetEmployee
                {
                    PageTitle = "Employees",
                };

                List<EmployeModel> employees = employeeDataSource.GetEmployeeByEntreprise(idEntreprise);

                if (employees != null && employees.Any())
                {
                    viewModel.EmployeeToEntreprise = EmployeeViewModel.FromEmployeeModel(employees);
                }

                return View("Index", viewModel);
            }

            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult UpdateVehicule()
        {
            var entrepriseId = User.FindFirstValue("EntrepriseId");
            if (entrepriseId != null)
            {
                var idEntreprise = int.Parse(entrepriseId);
                var viewModel = new UpdateVehiculeViewModel
                {
                    Employees = employeeDataSource.GetEmployeeByEntreprise(idEntreprise)
                        .Where(e => e.VehiculeId == null) 
                        .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nom }).ToList(),
                    Vehicules = vehiculeDataSource.GetVehiculeByEntreprise(idEntreprise)
                        .Where(v => v.EmployeId == null) 
                        .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Marque + " " + v.Modele })
                        .ToList()
                };

                return View(viewModel);
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateVehicule(UpdateVehiculeViewModel model)
        {
            employeeDataSource.UpdateVehicule(model.SelectedVehiculeId, model.SelectedEmployeeId);
         
            var entrepriseId = User.FindFirstValue("EntrepriseId");
            if (entrepriseId != null)
            {
                var idEntreprise = int.Parse(entrepriseId);
                model.Employees = employeeDataSource.GetEmployeeByEntreprise(idEntreprise)
                    .Where(e => e.VehiculeId == null) 
                    .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nom })
                    .ToList();

                model.Vehicules = vehiculeDataSource.GetVehiculeByEntreprise(idEntreprise)
                    .Where(v => v.EmployeId == null) 
                    .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Marque + " " + v.Modele })
                    .ToList();
            }
            
            return RedirectToAction("GetVehiculeByEntrepriseForUser", "Vehicule");
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult DeleteVehicule(int idVehicule, int idEmployee)
        {
            employeeDataSource.DeleteVehicule(idVehicule, idEmployee);
            return RedirectToAction("GetEmployeeByEntrepriseForUser");
        }
    }
}