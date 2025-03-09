using AutoParc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoParc.DataContext.EntityTypesConfiguration;

public class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<EmployeModel>
{
    public void Configure(EntityTypeBuilder<EmployeModel> builder)
    {
        builder.HasKey(e => e.Id);


        builder.HasOne(e => e.Entreprise)
            .WithMany(e => e.Employes)
            .HasForeignKey(e => e.EntrepriseId);



        builder.HasOne(e => e.Vehicule)
            .WithOne(v => v.Employe)
            .HasForeignKey<EmployeModel>(e => e.VehiculeId);

    }
}