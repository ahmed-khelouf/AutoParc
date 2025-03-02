using AutoParc.DataContext.EntityTypesConfiguration;
using AutoParc.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoParc.DataContext;

public class MainDbContext : DbContext
{
    protected MainDbContext()
    {
    }

    public MainDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Application des configurations des entités
        modelBuilder.ApplyConfiguration(new EntrepriseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VehiculeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeEntityTypeConfiguration());
        
        SeedDatabase(modelBuilder);
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntrepriseModel>()
            .HasData(
                new EntrepriseModel { Id = 1, Nom = "Test 1", ContratActif = true },
                new EntrepriseModel { Id = 2, Nom = "Test 2", ContratActif = false },
                new EntrepriseModel { Id = 3, Nom = "Test 3", ContratActif = true }
                );
        
        modelBuilder.Entity<EmployeModel>()
            .HasData(
                new EmployeModel { Id = 1, Nom = "Test 1", Prenom = "Test 1",  EntrepriseId = 1  , VehiculeId = 1},
                new EmployeModel { Id = 2, Nom = "Test 2", Prenom = "Test 2",  EntrepriseId = 2 , VehiculeId = 2 },
                new EmployeModel { Id = 3, Nom = "Test 3", Prenom = "Test 3",  EntrepriseId = 3 , VehiculeId = 3}
                );
        
        modelBuilder.Entity<VehiculeModel>()
            .HasData(
                new VehiculeModel { Id = 1, Marque = "Test 1", Modele = "Test 1",  EntrepriseId = 1  , Disponibilite = true , EmployeId = 1},
                new VehiculeModel { Id = 2, Marque = "Test 2", Modele = "Test 2",  EntrepriseId = 2 , Disponibilite = false , RaisonIndisponibilite = "Test 2" , EmployeId = 2},
                new VehiculeModel { Id = 3, Marque = "Test 3", Modele = "Test 3",  EntrepriseId = 3 , Disponibilite = true , EmployeId = 3}
            );
                
    }

    public DbSet<EntrepriseModel> Entreprise { get; set; }
    public DbSet<VehiculeModel> Vehicule { get; set; }
    public DbSet<EmployeModel> Employe { get; set; }
    
}