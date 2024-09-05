using System;
using System.Collections.Generic;

namespace SHG.Models;

public partial class BikramSambatRefTbl
{
    public DateOnly? StartDateAd { get; set; }

    public string? StartDateBs { get; set; }

    public DateOnly? EndDateAd { get; set; }

    public string? EndDateBs { get; set; }

    public int? FyStartYrBs { get; set; }

    public int? FyEndYrBs { get; set; }

    public string? Intervaltype { get; set; }

    public int? TimePeroid { get; set; }
}
