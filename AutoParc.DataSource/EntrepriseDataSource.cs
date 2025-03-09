using AutoParc.DataContext;
using AutoParc.DataSource.Interface;
using AutoParc.Model;

namespace AutoParc.DataSource;

public class EntrepriseDataSource : IEntrepriseDataSource
{
    private readonly MainDbContext _context;

    public EntrepriseDataSource(MainDbContext context)
    {
        _context = context;
    }
    
    
    public IEnumerable<EntrepriseModel> GetEntreprises()
    {
        IEnumerable<EntrepriseModel> entreprises = _context.Entreprise;
        return entreprises;
    }

    public void AddOrUpdateEntreprise(EntrepriseModel entrepriseToAdd)
    {
        if(entrepriseToAdd.Id.HasValue)
        {
            bool exists = _context.Entreprise.Any(e => e.Id == entrepriseToAdd.Id);

            if (!exists)
            {
                return;
            }
            _context.Entreprise.Update(entrepriseToAdd);
        }
        else
        {
            _context.Entreprise.Add(entrepriseToAdd);
        }
        _context.SaveChanges();
    }

    public EntrepriseModel? GetEntrepriseById(int id)
    {
        return _context.Entreprise.SingleOrDefault(e => e.Id == id);
    }

}