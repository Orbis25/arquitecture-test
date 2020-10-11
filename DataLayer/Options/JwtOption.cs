using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Options
{
    public class JwtOption
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecretKey { get; set; }
    }
}
