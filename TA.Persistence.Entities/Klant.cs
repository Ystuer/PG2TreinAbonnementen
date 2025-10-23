using System;
using System.Collections.Generic;

namespace TA.Persistence.Entities;

public partial class Klant
{
    public int Id { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Naam { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();
}
