using System;
using System.Collections.Generic;

namespace EntityFrame.newEf;

public partial class Company
{
    public int UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyType { get; set; }

    public string? Experience { get; set; }

    public string? CompanyDescription { get; set; }

    public virtual TrainerDetaile User { get; set; } = null!;
}
