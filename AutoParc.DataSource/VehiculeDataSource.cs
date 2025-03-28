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

    public IEnumerable<VehiculeModel> GetVehicules()
    {
        IEnumerable<VehiculeModel> vehicules = _context.Vehicule;
        return vehicules;
    }
    
    public List<VehiculeModel> GetVehiculeByEntreprise(int EntrepriseId)
    {
        var vehicules = _context.Vehicule
            .Where(v => v.EntrepriseId == EntrepriseId)
            .Include(v => v.Entreprise)
            .Include(v => v.Employe) 
            .ToList();
    
        return vehicules;  
    }
    
    public void AddOrUpdateVehicule(VehiculeModel vehiculeToAdd)
    {
        if (vehiculeToAdd.Id.HasValue)
        {
            bool exists = _context.Vehicule.Any(e => e.Id == vehiculeToAdd.Id);

            if (!exists)
            {
                return;
            }

            if (!vehiculeToAdd.Disponibilite)
            {
                var employe = _context.Employe.SingleOrDefault(e => e.VehiculeId == vehiculeToAdd.Id);
                if (employe != null)
                {
                    employe.VehiculeId = null;
                    _context.Employe.Update(employe);
                }
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