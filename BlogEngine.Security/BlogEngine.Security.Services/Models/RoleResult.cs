using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Security.Services.Models
{
    public class RoleResult
    {
        public short RoleId { get; set; }
        public string Description { get; set; }
        public byte State { get; set; }
    }
}
