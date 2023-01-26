using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

public partial class Skill
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("Skill_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SkillName { get; set; }

    [Column("Skill_Type")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SkillType { get; set; }

    [Column("Skill_Level")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SkillLevel { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Skill")]
    public virtual TrainerDetaile User { get; set; } = null!;
}
