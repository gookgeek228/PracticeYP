using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string? EventName { get; set; }

    public DateTime? Date { get; set; }

    public int? Days { get; set; }

    public int? IdCity { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual City? IdCityNavigation { get; set; }

    public virtual ICollection<UserModer> UserModers { get; set; } = new List<UserModer>();
}
