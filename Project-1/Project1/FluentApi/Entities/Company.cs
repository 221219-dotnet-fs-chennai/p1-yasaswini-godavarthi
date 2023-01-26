using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

[Table("Company")]
public partial class Company
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("Company_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string? CompanyName { get; set; }

    [Column("Company_type")]
    [StringLength(30)]
    [Unicode(false)]
    public string? CompanyType { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Experience { get; set; }

    [Column("Company_Description")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CompanyDescription { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Company")]
    public virtual TrainerDetaile User { get; set; } = null!;
}
