namespace AutoParc.Model;

public class VehiculeModel
{
     public int? Id { get; set; }
     
     public string Marque { get; set; }
     
     public string Modele { get; set; }
     
     public bool  Disponibilite { get; set; }
     
     public string? RaisonIndisponibilite { get; set; }
     
     public int EntrepriseId { get; set; }
     public EntrepriseModel? Entreprise { get; set; } 
     
     public int? EmployeId { get; set; } 
     public EmployeModel? Employe { get; set; }
}