using AutoParc.Model;

namespace AutoParc.WebUI.ViewsModels.Employee;

public class EmployeeViewModel
{
    public int Id { get; set; }
    
    public string Nom { get; set; }
    
    public string Prenom { get; set; }
    
    public int? EntrepriseId { get; set; }
    
    public int? VehiculeId { get; set; }
    
    public EmployeModel ToEmployeeModel(int EntrepriseId)
    {
        return new EmployeModel
        {
            Id = this.Id,
            Nom = this.Nom, 
            Prenom = this.Prenom,
            EntrepriseId = EntrepriseId,
            VehiculeId = this.VehiculeId,
           
        };
    }
    
    public static EmployeeViewModel FromEmployeeeModel(EmployeModel model)
    {
        return new EmployeeViewModel()
        {
            Id = model.Id,
            Nom = model.Nom,
            Prenom = model.Prenom,
            EntrepriseId = model.EntrepriseId,
            VehiculeId = model.VehiculeId,
        };
    }
    
    
    public static List<EmployeeViewModel> FromEmployeeModel(List<EmployeModel> employees)
    {
        return employees.Select(v => FromEmployeeeModel(v)).ToList();
    }
}