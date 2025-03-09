using AutoParc.Model;

namespace AutoParc.WebUI.ViewsModels.Vehicule;

public class VehiculeViewModel
{
    public int? Id { get; set; }
     
    public string Marque { get; set; }
     
    public string Modele { get; set; }
     
    public bool  Disponibilite { get; set; }
     
    public string? RaisonIndisponibilite { get; set; }
     
    public int? EntrepriseId { get; set; }
    public EntrepriseModel? Entreprise { get; set; } 

    //public int? EmployeId { get; set; } 
    //public EmployeModel Employe { get; set; }
    
    
    public VehiculeModel ToVehiculeModel(int EntrepriseId)
    {
        return new VehiculeModel
        {
            Id = this.Id,
            Marque = this.Marque,
            Modele = this.Modele,
            Disponibilite = this.Disponibilite,
            RaisonIndisponibilite = this.RaisonIndisponibilite,
            EntrepriseId = EntrepriseId,
            //Entreprise = this.Entreprise,
            //EmployeId = this.EmployeId,
            //Employe = this.Employe
        };
    }

    public static VehiculeViewModel FromVehiculeModel(VehiculeModel model)
    {
        return new VehiculeViewModel()
        {
            Id = model.Id,
            Marque = model.Marque,
            Modele = model.Modele,
            Disponibilite = model.Disponibilite,
            RaisonIndisponibilite = model.RaisonIndisponibilite,
            EntrepriseId = model.EntrepriseId,
            Entreprise = model.Entreprise,
            //EmployeId = model.EmployeId,
            //Employe = model.Employe
        };
    }
    
    
    
    public static List<VehiculeViewModel> FromVehiculeModel(List<VehiculeModel> vehicules)
    {
        return vehicules.Select(v => FromVehiculeModel(v)).ToList();
    }

  

}