using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.EntitiesConfigurations
{
    /*fichier de configuration des entités ef core, 
    * cette class dois hértiée de IentityTypeConfiguration<T>. T étant la class originel de models
    * Devras remplir le contrat Configure, qui prendra en parametre le type EntityTypeBuilder<t> builder
    */
    public class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
    {
        //c'est dans la méthode configure implémentée par l'interface que nous allons définir 
        //tous les éléments nécessaires au bon fonctionnement de nos tables EF
        //la suite est assez parlante pour est compréhensible
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            //nom de la table
            builder.ToTable("Brewery");

            //Primary key
            builder.HasKey("Id");

            //afin de généré l'id automatiquement j'ajoute le ValueGeneratedOnAdd
            builder.Property(nameof(Brewery.Id))
                   .ValueGeneratedOnAdd();

            //Les propriété et leur spécificité
            builder.Property(nameof(Brewery.Name))
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
