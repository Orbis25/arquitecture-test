using DataLayer.Commons;
using DataLayer.Models.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Persons
{
    public class Person : CommonProp
    {
        public string Name { get; set; }
        public Guid WorkId { get; set; }
        public Work Work { get; set; }
    }
}
