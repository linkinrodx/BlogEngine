// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngine.Data.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            LogPost = new HashSet<LogPost>();
        }

        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public short PostStateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishingDate { get; set; }

        public virtual User Author { get; set; }
        public virtual PostState PostState { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<LogPost> LogPost { get; set; }
    }
}