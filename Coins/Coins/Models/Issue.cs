using Coins.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coins.Models
{
    public class Issue
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public IssueType Type {get; set; }
        public HighVoltage HighVoltage { get; set; }
        public RepairType RepairType { get; set; }
        public int SurfaceSize { get; set; }
        public string ContactNumber { get; set; }
        public List<string> Pictures { get; set; }
    }
}
