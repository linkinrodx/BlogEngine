﻿namespace BlogEngine.Services.Models
{
    public class AddPostParameters
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
