using AutoParc.Model;

namespace AutoParc.DataSource.Interface;

public interface IEntrepriseDataSource
{
    public IEnumerable<EntrepriseModel> GetEntreprises();
}