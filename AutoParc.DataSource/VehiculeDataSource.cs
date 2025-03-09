using AutoParc.DataContext;
using AutoParc.DataSource.Interface;
using AutoParc.Model;
using Microsoft.EntityFrameworkCore;

public class VehiculeDataSource : IVehiculeDataSource
{
    private readonly MainDbContext _context;

    public VehiculeDataSource(MainDbContext context)
    {
        _context = context;
    }

    public List<VehiculeModel> GetVehiculeByEntreprise(int EntrepriseId)
    {
        var vehicules = _context.Vehicule
            .Where(v => v.EntrepriseId == EntrepriseId)
            .Include(v => v.Entreprise)  
            .ToList();
    
        return vehicules;  
    }
    
    public void AddOrUpdateVehicule(VehiculeModel vehiculeToAdd)
    {
        if(vehiculeToAdd.Id.HasValue)
        {
            bool exists = _context.Vehicule.Any(e => e.Id == vehiculeToAdd.Id);

            if (!exists)
            {
                return;
            }
            _context.Vehicule.Update(vehiculeToAdd);
        }
        else
        {
            _context.Vehicule.Add(vehiculeToAdd);
        }
        _context.SaveChanges();
    }
    
    public VehiculeModel? GetVehiculeById(int id)
    {
        return _context.Vehicule.SingleOrDefault(e => e.Id == id);
    }
}