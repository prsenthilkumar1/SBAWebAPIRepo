using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBAWebAPI.Models
{
    public class ParentTaskModel
    {
        public int ParentTask { get; set; }
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}