using Coins.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coins.Models
{
    public class Mechanical : Issue
    {
        public RepairType RepairType { get; set; }
    }
}
