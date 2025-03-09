using AutoParc.DataContext;
using AutoParc.DataSource.Interface;
using AutoParc.Model;

namespace AutoParc.DataSource;

public class VehiculeDataSource : IVehiculeDataSource
{
    private readonly MainDbContext _context;

    public VehiculeDataSource(MainDbContext context)
    {
        _context = context;
    }

    public List<VehiculeModel> GetVehiculeByEntreprise(int EntrepriseId)
    {
        var vehicules = _context.Vehicule.Where(v => v.EntrepriseId == EntrepriseId).ToList();
    
        return vehicules;  
    }
    
}