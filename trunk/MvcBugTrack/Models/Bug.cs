using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBugTrack.Models
{
    public class Bug
    {
        public int ID { get; set; }
        public string ShortDescription { get; set; }
        public int Project { get; set; }
        public int Category { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int AssignedTo { get; set; }
        public int ReportedBy { get; set; }
    }
}