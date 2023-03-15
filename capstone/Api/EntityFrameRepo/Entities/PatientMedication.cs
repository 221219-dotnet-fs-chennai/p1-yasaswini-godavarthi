using System;
using System.Collections.Generic;

namespace EntityFrameRepo.Entities;

public partial class PatientMedication
{
    public Guid Id { get; set; }

    public Guid? HealthId { get; set; }

    public string? Drug { get; set; }

    public virtual PatientHealthRecord? Health { get; set; }
}
