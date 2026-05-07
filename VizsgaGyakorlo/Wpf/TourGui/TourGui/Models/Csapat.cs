using System;
using System.Collections.Generic;

namespace TourGui.Models;

public partial class Csapat
{
    public int Id { get; set; }

    public string CsapatNev { get; set; } = null!;

    public virtual ICollection<Versenyzo> Versenyzos { get; set; } = new List<Versenyzo>();
}
