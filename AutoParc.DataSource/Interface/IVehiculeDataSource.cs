using AutoParc.Model;

namespace AutoParc.DataSource.Interface;

public interface IVehiculeDataSource
{
    public List<VehiculeModel> GetVehiculeByEntreprise(int EntrepriseId);
    
    public void AddOrUpdateVehicule(VehiculeModel vehiculeToAdd);
    
    public VehiculeModel? GetVehiculeById(int id);

    public IEnumerable<VehiculeModel> GetVehicules();
}