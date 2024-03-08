using System;
using System.Collections.Generic;

namespace Agenda2.Agenda2DB;

public partial class Tache
{
    public int IdTache { get; set; }

    public string NomTache { get; set; } = null!;

    public sbyte FaitTache { get; set; }

    public string DatelimTache { get; set; } = null!;

    public int EvenementIdevenement { get; set; }

    public virtual Evenement EvenementIdevenementNavigation { get; set; } = null!;
}