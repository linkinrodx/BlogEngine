﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngine.Security.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public short RoleId { get; set; }
        public string Description { get; set; }
        public byte State { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}