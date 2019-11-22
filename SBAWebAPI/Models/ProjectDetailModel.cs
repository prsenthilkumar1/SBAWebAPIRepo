using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBAWebAPI.Models
{
    public class ProjectDetailModel
    {
        public int PDProjectID { get; set; }
        public string PDProjectName { get; set; }
        public int NoOfTask { get; set; }
        public int TaskCompleted { get; set; }
        public DateTime? PDStartDate { get; set; }
        public DateTime? PDEndDate { get; set; }
        public int PDPriority { get; set; }
        public int UserID { get; set; }
    }
}