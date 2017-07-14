using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models
{
    public class PostCommentModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public PostCommentModel()
        {
            this.Post = new Post();
            this.Comments = new List<Comment>();

        }
    }
}