using DataLayer.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Works
{
    public class TaskWork : CommonProp
    {
        public Guid TaskId { get; set; }
        public TaskW Task { get; set; }
        public Guid WorkId { get; set; }
        public Work Work { get; set; }
    }
}
