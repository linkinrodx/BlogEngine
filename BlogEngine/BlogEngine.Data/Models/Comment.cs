﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngine.Data.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public byte State { get; set; }

        public virtual Post Post { get; set; }
    }
}