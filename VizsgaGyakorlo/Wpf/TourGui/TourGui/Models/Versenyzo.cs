using System;
using System.Collections.Generic;

namespace TourGui.Models;

public partial class Versenyzo
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int CsapatId { get; set; }

    public string Nemzetiseg { get; set; } = null!;

    public virtual Csapat Csapat { get; set; } = null!;

    public virtual ICollection<Eredmeny> Eredmenies { get; set; } = new List<Eredmeny>();
}
