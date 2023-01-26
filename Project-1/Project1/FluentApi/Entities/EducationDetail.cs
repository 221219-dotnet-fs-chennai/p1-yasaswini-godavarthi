using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

[Table("Education_Details")]
public partial class EducationDetail
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("Highest_Graduation")]
    [StringLength(30)]
    [Unicode(false)]
    public string? HighestGraduation { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Institute { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Department { get; set; }

    [Column("Start_year")]
    [StringLength(5)]
    [Unicode(false)]
    public string? StartYear { get; set; }

    [Column("End_year")]
    [StringLength(5)]
    [Unicode(false)]
    public string? EndYear { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("EducationDetail")]
    public virtual TrainerDetaile User { get; set; } = null!;
}
