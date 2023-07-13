using _01_DB.DataSet;
using _01_DB.Entities;
using _01_DB.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace _01_DB
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
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
            modelBuilder.ApplyConfiguration(new EstimateConfiguration());
            modelBuilder.ApplyConfiguration(new BeerEstimateConfiguration());

            //data seed
            modelBuilder.ApplyConfiguration(new DataSetBrewery());
            modelBuilder.ApplyConfiguration(new DataSetBeer());
            modelBuilder.ApplyConfiguration(new DataSetWholesaler());
            modelBuilder.ApplyConfiguration(new DataSetStockBeerWholeSaler());
        }

        //Les DBSet qui vont créer des objets IQueryable à qui on pourra envoyer des requêt Linq
        public DbSet<Brewery> breweries { get; set; }
        public DbSet<Beer> beers { get; set; }
        public DbSet<Wholesaler> wholesalers { get; set; }
        public DbSet<StockBeerWholesaler> stockBeerWholesalers { get; set; }
        public DbSet<Estimate> estimates { get; set; }
        public DbSet<BeerEstimate> beersEstimates { get; set; }

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
