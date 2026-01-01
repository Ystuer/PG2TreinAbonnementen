namespace TA.Persistence.Dapper
{
    public class Abonnement
    {
        public int Id { get; set; }

        public DateOnly Startdatum { get; set; }

        public DateOnly Einddatum { get; set; }

        public string Klasse { get; set; } = null!;

        public Station AankomstStation { get; set; } = null!;

        public Klant Klant { get; set; } = null!;

        public Station VertrekStation { get; set; } = null!;
    }
}
