using AutoParc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoParc.DataContext.EntityTypesConfiguration;

public class EntrepriseEntityTypeConfiguration : IEntityTypeConfiguration<EntrepriseModel>
{
    public void Configure(EntityTypeBuilder<EntrepriseModel> builder)
    {
        
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Vehicules)
            .WithOne(v => v.Entreprise)
            .HasForeignKey(v => v.EntrepriseId);


        builder.HasMany(e => e.Employes)
            .WithOne(emp => emp.Entreprise)
            .HasForeignKey(emp => emp.EntrepriseId);

    }
}