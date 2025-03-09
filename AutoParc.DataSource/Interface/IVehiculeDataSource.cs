using AutoParc.Model;

namespace AutoParc.DataSource.Interface;

public interface IVehiculeDataSource
{
    public List<VehiculeModel> GetVehiculeByEntreprise(int EntrepriseId);
}