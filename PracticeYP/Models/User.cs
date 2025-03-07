using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class User
{
    public int IdUsers { get; set; }

    public string? Fio { get; set; }

    public string? Email { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? IdCountry { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public byte[]? Photo { get; set; }

    public string? IdGender { get; set; }

    public int? IdRole { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<UserJuri> UserJuris { get; set; } = new List<UserJuri>();

    public virtual ICollection<UserModer> UserModers { get; set; } = new List<UserModer>();
}
