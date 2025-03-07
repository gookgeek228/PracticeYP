using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class Action
{
    public int IdAction { get; set; }

    public int? IdEvent { get; set; }

    public int? IdJury1 { get; set; }

    public int? IdJury2 { get; set; }

    public int? IdJury3 { get; set; }

    public int? IdJury4 { get; set; }

    public int? IdJury5 { get; set; }

    public int? IdModer { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateOnly? DateStart { get; set; }

    public string? Actions { get; set; }

    public int? IdWinner { get; set; }

    public int? Day { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual UserJuri? IdJury1Navigation { get; set; }

    public virtual UserJuri? IdJury5Navigation { get; set; }

    public virtual UserModer? IdModerNavigation { get; set; }

    public virtual User? IdWinnerNavigation { get; set; }
}
