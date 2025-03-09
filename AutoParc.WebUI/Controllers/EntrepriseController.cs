using System.Diagnostics;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.AspNetCore.Mvc;
using AutoParc.WebUI.Models;
using AutoParc.WebUI.ViewsModels.Entreprise;
using Microsoft.AspNetCore.Authorization;

namespace AutoParc.WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class EntrepriseController : Controller
{
    private readonly IEntrepriseDataSource entrepriseDataSource;
    
    
    public EntrepriseController(IEntrepriseDataSource entrepriseDataSource)
    {
        this.entrepriseDataSource = entrepriseDataSource;
    }

    public IActionResult Index()
    {
        IEnumerable<EntrepriseModel> entreprises = entrepriseDataSource.GetEntreprises(); 
        
        EntrepriseIndexViewModel indexViewModel = new EntrepriseIndexViewModel();
        indexViewModel.PageTitle = "Liste des entreprises";
        
        indexViewModel.Entreprise = new();
        foreach (var e in entreprises)
        {
            indexViewModel.Entreprise.Add(EntrepriseViewModel.FromEntrepriseModel(e));
        }
        return View(indexViewModel);
    }

    [HttpGet]
    public IActionResult AddOrEdit(int? id = null)
    {
        AddOrEditEntrepriseViewModel addOrEditEntrepriseViewModel = new AddOrEditEntrepriseViewModel();

        if (id.HasValue)
        {
            EntrepriseModel? entreprise = entrepriseDataSource.GetEntrepriseById(id.Value);

            if (entreprise != null)
            {
                addOrEditEntrepriseViewModel.EntrepriseToAddOrEdit = EntrepriseViewModel.FromEntrepriseModel(entreprise);
            }
        }
        else
        {
            addOrEditEntrepriseViewModel.EntrepriseToAddOrEdit = new EntrepriseViewModel
            {
                ContratActif = true  
            };
        }

        return View(addOrEditEntrepriseViewModel);
    }


    [HttpPost]
    public IActionResult AddOrEdit(AddOrEditEntrepriseViewModel model)
    {
        if (ModelState.IsValid)
        {
            EntrepriseModel entrepriseToAdd = model.EntrepriseToAddOrEdit.ToEntrepriseModel();
            entrepriseDataSource.AddOrUpdateEntreprise(entrepriseToAdd);
            return RedirectToAction("Index");
        }
        return View(model);
    }
}