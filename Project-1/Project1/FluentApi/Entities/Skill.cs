using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class Skill
{
    public int UserId { get; set; }

    public string? SkillName { get; set; }

    public string? SkillType { get; set; }

    public string? SkillLevel { get; set; }

    public virtual TrainerDetaile User { get; set; } = null!;
}
