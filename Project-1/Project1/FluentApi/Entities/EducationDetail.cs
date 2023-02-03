using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class EducationDetail
{
    public int UserId { get; set; }

    public string? HighestGraduation { get; set; }

    public string? Institute { get; set; }

    public string? Department { get; set; }

    public string? StartYear { get; set; }

    public string? EndYear { get; set; }

    public virtual TrainerDetaile User { get; set; } = null!;
}
