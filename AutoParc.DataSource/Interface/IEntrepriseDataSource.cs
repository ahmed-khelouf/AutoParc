using AutoParc.Model;

namespace AutoParc.DataSource.Interface;

public interface IEntrepriseDataSource
{
    public IEnumerable<EntrepriseModel> GetEntreprises();
    
    public void AddOrUpdateEntreprise(EntrepriseModel entrepriseToAdd);
    
    public EntrepriseModel? GetEntrepriseById(int id);
}