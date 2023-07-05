using _01_DB.DataSet;
using _01_DB.Entities;
using _01_DB.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DB
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=GenesisBeerDB"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //logique
            modelBuilder.ApplyConfiguration(new BreweryConfiguration());
            modelBuilder.ApplyConfiguration(new BeerConfiguration());
            modelBuilder.ApplyConfiguration(new WholesalerConfiguration());
            modelBuilder.ApplyConfiguration(new StockBeerWholesalerConfiguration());

            //data seed
            modelBuilder.ApplyConfiguration(new DataSetBrewery());
            modelBuilder.ApplyConfiguration(new DataSetBeer());
            modelBuilder.ApplyConfiguration(new DataSetWholesaler());
            modelBuilder.ApplyConfiguration(new DataSetStockBeerWholeSaler());
        }

        //Les DBSet qui vont créer des objets IQueryable à qui on pourra envoyer des requêt Linq
        DbSet<Brewery> breweries {  get; set; }
        DbSet<Beer> beers { get; set; }
        DbSet<Wholesaler> wholesalers { get; set; }
        DbSet<StockBeerWholesaler> stockBeerWholesalers { get; set; }

        //PMC ou Package Manager console
        //la première commande à connaître c'est celle du helper get-help EntityFrameworkCore
        //la suivante que nous allons utiliser est "add-migration nom_de_la_migration"
        //ça va générer du code c# qui sera i nterprété par EF pour la création de la base de donnée.
        //il sera placé dans un classe nomée "datetim_nomMigration" dans un répertoir Migrations généré par EF lui aussi

        //a chaque nouvelle mise à jour de la structure de la db pn créera une nouvelle migration
        //il n'y a que la derni!re migration qui sera prise en charge par la commande:
        //Update-Database

        //il est possible de faire un downgrade / rollback en utilisant Update-Database nom_de_la_migration_antérieur
        //les scripts généré par la migration sont modifiable avant l'exécution de la commande d'update
    }
}
