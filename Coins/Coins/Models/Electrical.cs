using Coins.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coins.Models
{
    public class Electrical : Issue
    {
        public HighVoltage HighVoltage { get; set; }
    }
}
