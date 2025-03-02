using AutoParc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoParc.DataContext.EntityTypesConfiguration;

public class VehiculeEntityTypeConfiguration : IEntityTypeConfiguration<VehiculeModel>
{
    public void Configure(EntityTypeBuilder<VehiculeModel> builder)
    {
        builder.HasKey(v => v.Id);  

        builder.HasOne(v => v.Entreprise) 
            .WithMany(e => e.Vehicules) 
            .HasForeignKey(v => v.EntrepriseId); 
    }
}