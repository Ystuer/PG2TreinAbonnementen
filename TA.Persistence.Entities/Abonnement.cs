using System;
using System.Collections.Generic;

namespace TA.Persistence.Entities;

public partial class Abonnement
{
    public int Id { get; set; }

    public int KlantId { get; set; }

    public int VertrekStationId { get; set; }

    public int AankomstStationId { get; set; }

    public DateOnly Startdatum { get; set; }

    public DateOnly Einddatum { get; set; }

    public string Klasse { get; set; } = null!;

    public virtual Station AankomstStation { get; set; } = null!;

    public virtual Klant Klant { get; set; } = null!;

    public virtual Station VertrekStation { get; set; } = null!;
}
