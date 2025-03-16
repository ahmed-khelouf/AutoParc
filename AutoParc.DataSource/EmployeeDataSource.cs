using AutoParc.DataContext;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoParc.DataSource;

public class EmployeeDataSource : IEmployeeDataSource
{
    
    private readonly MainDbContext _context;

    public EmployeeDataSource(MainDbContext context)
    {
        _context = context;
    }
    
    
    public List<EmployeModel> GetEmployeeByEntreprise(int EntrepriseId)
    {
        var employees = _context.Employe
            .Where(v => v.EntrepriseId == EntrepriseId)
            .Include(v => v.Entreprise)  
            .ToList();
    
        return employees;  
    }
    
    public void UpdateVehicule(int idVehicule, int idEmployee)
    {
        var employee = _context.Employe.FirstOrDefault(e => e.Id == idEmployee);
        if (employee != null)
        {
            employee.VehiculeId = idVehicule;
        }
    
        var vehicule = _context.Vehicule.FirstOrDefault(v => v.Id == idVehicule);
        if (vehicule != null)
        {
            vehicule.EmployeId = idEmployee;
        }
    
        _context.SaveChanges();
    }
    
    public void DeleteVehicule(int idVehicule, int idEmployee)
    {
        var employee = _context.Employe.FirstOrDefault(e => e.Id == idEmployee);
        if (employee != null)
        {
            employee.VehiculeId = null;
        }
    
        var vehicule = _context.Vehicule.FirstOrDefault(v => v.Id == idVehicule);
        if (vehicule != null)
        {
            vehicule.EmployeId = null;
        }
    
        _context.SaveChanges();
    }
    
    public void AddEmployee(EmployeModel employeeToAdd)
    {
        _context.Employe.Add(employeeToAdd);
        _context.SaveChanges();
    }
  
}