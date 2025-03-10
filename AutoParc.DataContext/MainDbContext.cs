using AutoParc.DataContext.EntityTypesConfiguration;
using AutoParc.Model;
using AutoParc.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoParc.DataContext;

public class MainDbContext : IdentityDbContext<UserModel>
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
        // Création du rôle "Admin"
        var adminRoleId = "role-admin";
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );

        // Création de l'utilisateur admin
        var adminUserId = "admin-user";
        var hasher = new PasswordHasher<UserModel>();
        var adminUser = new UserModel
        {
            Id = adminUserId,
            UserName = "admin@autoparc.com",
            Email = "admin@autoparc.com",
            NormalizedUserName = "ADMIN@AUTOPARC.COM",
            NormalizedEmail = "ADMIN@AUTOPARC.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        modelBuilder.Entity<UserModel>().HasData(adminUser);

        // Assignation du rôle "Admin" à l'utilisateur admin
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            }
        );
    
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
                new EmployeModel { Id = 3, Nom = "Test 3", Prenom = "Test 3",  EntrepriseId = 3 , VehiculeId = 3},
                new EmployeModel { Id = 4, Nom = "Test 4", Prenom = "Test 4",  EntrepriseId = 3 , VehiculeId = 4},
                new EmployeModel { Id = 5, Nom = "Test 5", Prenom = "Test 5",  EntrepriseId = 3 , VehiculeId = 5}
                );
        
        modelBuilder.Entity<VehiculeModel>()
            .HasData(
                new VehiculeModel { Id = 1, Marque = "Test 1", Modele = "Test 1",  EntrepriseId = 1  , Disponibilite = true , EmployeId = 1},
                new VehiculeModel { Id = 2, Marque = "Test 2", Modele = "Test 2",  EntrepriseId = 2 , Disponibilite = false , RaisonIndisponibilite = "Test 2" , EmployeId = 2},
                new VehiculeModel { Id = 3, Marque = "Test 3", Modele = "Test 3",  EntrepriseId = 3 , Disponibilite = true , EmployeId = 3},
                new VehiculeModel { Id = 4, Marque = "Test 4", Modele = "Test 4",  EntrepriseId = 3 , Disponibilite = true , EmployeId = 4},
                new VehiculeModel { Id = 5, Marque = "Test 5", Modele = "Test 5",  EntrepriseId = 3 , Disponibilite = true , EmployeId = 5}
            );
                
        
                
    }

    public DbSet<EntrepriseModel> Entreprise { get; set; }
    public DbSet<VehiculeModel> Vehicule { get; set; }
    public DbSet<EmployeModel> Employe { get; set; }
    
}