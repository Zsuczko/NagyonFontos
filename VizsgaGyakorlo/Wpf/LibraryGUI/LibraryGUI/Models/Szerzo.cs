using System;
using System.Collections.Generic;

namespace LibraryGUI.Models;

public partial class Szerzo
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Nemzetiseg { get; set; } = null!;

    public virtual ICollection<Konyv> Konyvs { get; set; } = new List<Konyv>();
}
