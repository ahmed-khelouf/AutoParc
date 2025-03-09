using AutoParc.Model;

namespace AutoParc.WebUI.ViewsModels.Entreprise;

public class EntrepriseViewModel
{
    public int? Id {get ; set;}
    
    public string Nom {get ; set;}
    
    public bool ContratActif {get ; set;}
    
    
    public EntrepriseModel ToEntrepriseModel()
    {
        return new EntrepriseModel
        {
            Id = this.Id,
            Nom = this.Nom,
            ContratActif = this.ContratActif,
        };
    }

    public static EntrepriseViewModel FromEntrepriseModel(EntrepriseModel model)
    {
        return new EntrepriseViewModel
        {
            Id = model.Id,
            Nom = model.Nom,
            ContratActif = model.ContratActif,
        };
    }
    
}