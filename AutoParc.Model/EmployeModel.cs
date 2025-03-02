namespace AutoParc.Model;

public class EmployeModel
{
    public int Id { get; set; }
    
    public string Nom { get; set; }
    
    public string Prenom { get; set; }
    
    public int EntrepriseId { get; set; }
    public EntrepriseModel Entreprise { get; set; } 
    
    public int? VehiculeId { get; set; } 
    public VehiculeModel Vehicule { get; set; }
}