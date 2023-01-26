using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

[Table("Trainer_Detailes")]
[Index("Email", Name = "UQ__Trainer___A9D10534E3AAECE5", IsUnique = true)]
public partial class TrainerDetaile
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("Full_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? Age { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [Column("Mobile_number")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MobileNumber { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Website { get; set; }

    [Column("PASSWORD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Password { get; set; }

    [InverseProperty("User")]
    public virtual Company? Company { get; set; }

    [InverseProperty("User")]
    public virtual EducationDetail? EducationDetail { get; set; }

    [InverseProperty("User")]
    public virtual Skill? Skill { get; set; }
}
