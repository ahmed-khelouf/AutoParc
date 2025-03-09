using AutoParc.Model;

namespace AutoParc.WebUI.ViewsModels.Entreprise;

public class EntrepriseViewModel
{
    public int Id {get ; set;}
    
    public string Nom {get ; set;}
    
    public bool ContratActif {get ; set;}
    
    public IList<VehiculeModel> Vehicules {get ; set;}
    
    public IList<EmployeModel> Employes {get ; set;}
    
    
    public EntrepriseViewModel ToEntrepriseModel()
    {
        return new EntrepriseViewModel
        {
            Id = this.Id,
            Nom = this.Nom,
            ContratActif = this.ContratActif,
            Vehicules = this.Vehicules.ToList(),
            Employes = this.Employes.ToList()
        };
    }

    public static EntrepriseViewModel FromEntrepriseModel(EntrepriseModel model)
    {
        return new EntrepriseViewModel()
        {
            Id = model.Id,
            Nom = model.Nom,
            ContratActif = model.ContratActif,
            Vehicules = model.Vehicules,
            Employes = model.Employes
        };
    }

    public static EntrepriseViewModel FromVehiculeModel(List<VehiculeModel> vehicules)
    {
        
        var entreprise = vehicules.FirstOrDefault()?.Entreprise;

        if (entreprise == null)
            return null;

        return new EntrepriseViewModel
        {
            Id = entreprise.Id,
            Nom = entreprise.Nom,
            ContratActif = entreprise.ContratActif,
            Vehicules = vehicules,
        };
    }

}