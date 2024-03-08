using System;
using System.Collections.Generic;

namespace Agenda2.Agenda2DB;

public partial class R
{
    public int Idrs { get; set; }

    public string NomRs { get; set; } = null!;

    public string IconRs { get; set; } = null!;

    public string UrlRs { get; set; } = null!;

    public virtual ICollection<Profil> Profils { get; set; } = new List<Profil>();

    public virtual ICollection<Contact> ContactIdcontacts { get; set; } = new List<Contact>();
}