using System;
using System.Collections.Generic;

namespace PracticeYP.Models;

public partial class Gender
{
    public string IdGender { get; set; } = null!;

    public string? GenderName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
