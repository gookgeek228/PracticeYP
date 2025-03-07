using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class Sector
{
    public int IdSector { get; set; }

    public string? SectorName { get; set; }

    public virtual ICollection<UserJuri> UserJuris { get; set; } = new List<UserJuri>();

    public virtual ICollection<UserModer> UserModers { get; set; } = new List<UserModer>();
}
