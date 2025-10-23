using System;
using System.Collections.Generic;

namespace TA.Persistence.Entities;

public partial class Station
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public bool VerwarmdeWachtruimte { get; set; }

    public virtual ICollection<Abonnement> AbonnementAankomstStations { get; set; } = new List<Abonnement>();

    public virtual ICollection<Abonnement> AbonnementVertrekStations { get; set; } = new List<Abonnement>();
}
