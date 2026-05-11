using System;
using System.Collections.Generic;

namespace LibraryGUI.Models;

public partial class Konyv
{
    public int Id { get; set; }

    public string Cim { get; set; } = null!;

    public int SzerzoId { get; set; }

    public string Mufaj { get; set; } = null!;

    public int KiadasEve { get; set; }

    public virtual ICollection<Kolcsonze> Kolcsonzes { get; set; } = new List<Kolcsonze>();

    public virtual Szerzo Szerzo { get; set; } = null!;
}
