using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBAWebAPI.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int ParentID { get; set; }
    }
}