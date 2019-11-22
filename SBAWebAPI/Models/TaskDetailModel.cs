using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBAWebAPI.Models
{
    public class TaskDetailModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int ParentTaskID { get; set; }
        public string ParentTaskName { get; set; }
        public int TaskPriority { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int TaskProjectID { get; set; }
        public string TaskProjectName { get; set; }
        public string TaskStatus { get; set; }
    }
}