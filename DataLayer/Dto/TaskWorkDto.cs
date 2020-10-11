using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dto
{
    public class TaskWorkDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public WorkDto Work { get; set; }
        public TaskWDto Task { get; set; }

    }

    public class WorkDto
    {
        public string WorkName { get; set; }
    }

    public class TaskWDto
    {
        public string Title { get; set; }
    }
}
