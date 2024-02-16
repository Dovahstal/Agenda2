using System;
using System.Collections.Generic;

namespace Agenda2.Agenda2DB;

public partial class Contact
{
    public int Idcontacts { get; set; }

    public string NomContact { get; set; } = null!;

    public string? PrenomContact { get; set; }

    public string EmailContact { get; set; } = null!;

    public string PhoneContact { get; set; } = null!;

    public string AdresseContact { get; set; } = null!;

    public string CodepostalContact { get; set; } = null!;

    public string VilleContact { get; set; } = null!;

    public string NaissanceContact { get; set; } = null!;

    public virtual ICollection<Profil> Profils { get; set; } = new List<Profil>();

    public virtual ICollection<R> RsIdrs { get; set; } = new List<R>();
}
