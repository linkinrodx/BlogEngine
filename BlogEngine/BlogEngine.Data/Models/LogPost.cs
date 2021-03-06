// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngine.Data.Models
{
    public partial class LogPost
    {
        public long LogPostId { get; set; }
        public int PostId { get; set; }
        public short PostStateId { get; set; }
        public int AuthorId { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }

        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
        public virtual PostState PostState { get; set; }
    }
}