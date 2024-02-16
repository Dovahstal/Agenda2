using System;
using System.Collections.Generic;

namespace Agenda2.Agenda2DB;

public partial class Evenement
{
    public int Idevenement { get; set; }

    public string NomEvenement { get; set; } = null!;

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
