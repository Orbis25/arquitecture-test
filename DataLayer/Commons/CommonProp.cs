using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Commons
{
    public class CommonProp
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string CreatedAtStr => CreatedAt.ToString("dd/MM/yyyy");
        public string UpdatedAtStr => CreatedAt.ToString("dd/MM/yyyy");

        public SharedStateEnum State { get; set; } = SharedStateEnum.Active;

    }
}
