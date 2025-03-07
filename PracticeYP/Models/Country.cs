using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string? Name { get; set; }

    public string? EnglishName { get; set; }

    public string? Code { get; set; }

    public int? Code2 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
