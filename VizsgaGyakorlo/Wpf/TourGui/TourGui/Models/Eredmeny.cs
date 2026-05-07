using System;
using System.Collections.Generic;

namespace TourGui.Models;

public partial class Eredmeny
{
    public int Id { get; set; }

    public int VersenyzoId { get; set; }

    public int Szakasz { get; set; }

    public TimeSpan Ido { get; set; }

    public virtual Versenyzo Versenyzo { get; set; } = null!;
}
