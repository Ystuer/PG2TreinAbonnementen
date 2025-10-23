namespace TA.Domain.Model
{
    public class KlantModel
    {
        public int Id { get; set; }
        public required string Voornaam { get; set; }
        public required string Naam { get; set; }
        public required string Email { get; set; }
        public string? fullName {  get; set; }

    }
}
