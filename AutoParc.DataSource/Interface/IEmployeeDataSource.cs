using AutoParc.Model;

namespace AutoParc.DataSource.Interface;

public interface IEmployeeDataSource
{
    public List<EmployeModel> GetEmployeeByEntreprise(int EntrepriseId);

    public void UpdateVehicule(int idVehicule , int idEmployee);
    public void DeleteVehicule(int idVehicule , int idEmployee);
    
}