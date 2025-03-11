namespace AutoParc.Model;

public class StatistiqueModel
{
    public int TotalEntreprises { get; set; }
    public int ActiveEntreprises { get; set; }
    public int InactiveEntreprises { get; set; }
    public int TotalVéhicules { get; set; }
    
    public int VehiculesDisponible { get; set; }
    
    public int VehiculesPasDispo { get; set; }
}