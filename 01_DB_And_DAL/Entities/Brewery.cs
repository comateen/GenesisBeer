namespace _01_DB.Entities
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //ajout pour faire lien dans le cadre de la relation One to many
        //propriété de navigation pour la relation 1-N
        public List<Beer> Beers { get; set; }

    }
}
