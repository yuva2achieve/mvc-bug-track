using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBugTrack.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}