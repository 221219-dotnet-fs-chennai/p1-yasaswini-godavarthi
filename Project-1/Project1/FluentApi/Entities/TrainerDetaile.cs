using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class TrainerDetaile
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? MobileNumber { get; set; }

    public string? Website { get; set; }

    public string? Password { get; set; }

    public virtual Company? Company { get; set; }

    public virtual EducationDetail? EducationDetail { get; set; }

    public virtual Skill? Skill { get; set; }
}
