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

}