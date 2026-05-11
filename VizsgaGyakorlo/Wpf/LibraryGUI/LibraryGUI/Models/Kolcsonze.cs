using System;
using System.Collections.Generic;

namespace LibraryGUI.Models;

public partial class Kolcsonze
{
    public int Id { get; set; }

    public int KonyvId { get; set; }

    public string OlvasoNev { get; set; } = null!;

    public DateOnly Datum { get; set; }

    public int Visszahozva { get; set; }

    public virtual Konyv Konyv { get; set; } = null!;
}
