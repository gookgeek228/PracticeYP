using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class UserJuri
{
    public int IdJuri { get; set; }

    public int? IdSector { get; set; }

    public int? IdUsers { get; set; }

    public virtual ICollection<Action> ActionIdJury1Navigations { get; set; } = new List<Action>();

    public virtual ICollection<Action> ActionIdJury5Navigations { get; set; } = new List<Action>();

    public virtual Sector? IdSectorNavigation { get; set; }

    public virtual User? IdUsersNavigation { get; set; }
}
