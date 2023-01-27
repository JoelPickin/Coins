using System;
using System.Collections.Generic;
using System.Text;

namespace Coins.Models
{
    public class Safety : Issue
    {
        public string ContactNumber { get; set; }
        public List<string> Pictures { get; set; }
    }
}
