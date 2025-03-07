using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class UserModer
{
    public int IdModer { get; set; }

    public int? IdUsers { get; set; }

    public int? IdSector { get; set; }

    public int? IdEvent { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Event? IdEventNavigation { get; set; }

    public virtual Sector? IdSectorNavigation { get; set; }

    public virtual User? IdUsersNavigation { get; set; }
}
