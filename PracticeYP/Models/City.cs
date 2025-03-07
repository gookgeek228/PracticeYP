using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class City
{
    public int IdCity { get; set; }

    public byte[]? CityImage { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
