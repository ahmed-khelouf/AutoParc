namespace AutoParc.Model;

public class EntrepriseModel
{
    public int? Id {get ; set;}
    
    public string Nom {get ; set;}
    
    public bool ContratActif {get ; set;}
    
    public IList<VehiculeModel>? Vehicules {get ; set;}
    
    public IList<EmployeModel>? Employes {get ; set;}
}