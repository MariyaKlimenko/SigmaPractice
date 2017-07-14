using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Data.Entity;

namespace ImageSharing.Business
{
    public class CommentHelper
    {
        private IRepository context;
        private UserHelper users;
        private PostHelper posts;

        public CommentHelper(IRepository repository)
        {
            this.context = repository;
            this.users = new UserHelper(this.context);
            this.posts = new PostHelper(this.context);
        }

        public Comment AddComment(string comment, int postid, int userid)
        {
            var c = new Comment() { Commentary = comment, CreatedAt = DateTime.Now };
            c.User = users.GetUser(userid);
            c.Post = posts.GetPost(postid);
            context.Add(c);
            context.SaveChanges();
            return c;
        }

        public void DeleteComment(int id)
        {
            var c = GetComment(id);
            context.Delete(c);
            context.SaveChanges();
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public Comment GetComment(int id)
        {
            return GetComments().First(x => x.ID == id);
        }

        public IEnumerable<Comment> GetPostComments(int postid)
        {
            return context.Comments.Where(x => x.Post != null && x.Post.ID == postid).ToList();
        }

    }
}
