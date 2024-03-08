using System;
using System.Collections.Generic;

namespace Agenda2.Agenda2DB;

public partial class Profil
{
    public int Idprofils { get; set; }

    public string PseudonymeProfils { get; set; } = null!;

    public string UrlProfil { get; set; } = null!;

    public int ContactIdcontacts { get; set; }

    public int RsIdrs { get; set; }

    public virtual Contact ContactIdcontactsNavigation { get; set; } = null!;

    public virtual R RsIdrsNavigation { get; set; } = null!;
}