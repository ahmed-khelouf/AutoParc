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
    var adminRoleId = "role-admin";
    modelBuilder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
            Id = adminRoleId,
            Name = "Admin",
            NormalizedName = "ADMIN"
        }
    );
    
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

    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = adminRoleId
        }
    );


    var clientUserId = "client-user";
    var clientUser = new UserModel
    {
        Id = clientUserId,
        UserName = "client@autoparc.com",
        Email = "client@autoparc.com",
        NormalizedUserName = "CLIENT@AUTOPARC.COM",
        EntrepriseId = 1,
        NormalizedEmail = "CLIENT@AUTOPARC.COM",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString()
    };
    clientUser.PasswordHash = hasher.HashPassword(clientUser, "Client123!");

    modelBuilder.Entity<UserModel>().HasData(clientUser);

  
    var clientRoleId = "role-client";
    modelBuilder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
            Id = clientRoleId,
            Name = "Client",
            NormalizedName = "CLIENT"
        }
    );

    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
            UserId = clientUserId,
            RoleId = clientRoleId,
        }
    );

  
    modelBuilder.Entity<EntrepriseModel>()
        .HasData(
            new EntrepriseModel { Id = 1, Nom = "Entreprise Alpha", ContratActif = true },
            new EntrepriseModel { Id = 2, Nom = "Entreprise Beta", ContratActif = false },
            new EntrepriseModel { Id = 3, Nom = "Entreprise Gamma", ContratActif = true }
        );

 
    modelBuilder.Entity<EmployeModel>()
        .HasData(
            new EmployeModel { Id = 1, Nom = "Dupont", Prenom = "Jean", EntrepriseId = 1, VehiculeId = 1 },
            new EmployeModel { Id = 2, Nom = "Martin", Prenom = "Paul", EntrepriseId = 2, VehiculeId = 2 },
            new EmployeModel { Id = 3, Nom = "Durand", Prenom = "Marie", EntrepriseId = 3, VehiculeId = 3 },
            new EmployeModel { Id = 4, Nom = "Petit", Prenom = "Luc", EntrepriseId = 3, VehiculeId = 4 },
            new EmployeModel { Id = 5, Nom = "Leroy", Prenom = "Sophie", EntrepriseId = 3, VehiculeId = 5 }
        );


    modelBuilder.Entity<VehiculeModel>()
        .HasData(
            new VehiculeModel { Id = 1, Marque = "Renault", Modele = "Clio", EntrepriseId = 1, Disponibilite = true, EmployeId = 1 },
            new VehiculeModel { Id = 2, Marque = "Peugeot", Modele = "208", EntrepriseId = 2, Disponibilite = false, RaisonIndisponibilite = "En réparation", EmployeId = 2 },
            new VehiculeModel { Id = 3, Marque = "Citroën", Modele = "C3", EntrepriseId = 3, Disponibilite = true, EmployeId = 3 },
            new VehiculeModel { Id = 4, Marque = "Toyota", Modele = "Yaris", EntrepriseId = 3, Disponibilite = true, EmployeId = 4 },
            new VehiculeModel { Id = 5, Marque = "Ford", Modele = "Focus", EntrepriseId = 3, Disponibilite = true, EmployeId = 5 }
        );
}

    public DbSet<EntrepriseModel> Entreprise { get; set; }
    public DbSet<VehiculeModel> Vehicule { get; set; }
    public DbSet<EmployeModel> Employe { get; set; }
    
}