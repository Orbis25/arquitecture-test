using DataLayer.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Users
{
    public class User : CommonProp
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
