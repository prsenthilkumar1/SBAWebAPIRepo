using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBAWebAPI.Models
{
    public class ProjectModel
    {
        public int Project_ID { get; set; }
        public string Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int UserID { get; set; }
    }
}