using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.Data
{
    public class Repository : IRepository
    {
        ImageSharingContext context = new ImageSharingContext();

        public IEnumerable<Post> Posts
        {
            get
            {

                return context.Posts.Include("User").ToList();
            }
        }

        public IEnumerable<User> Users
        {
            get
            {

                return context.Users.ToList();
            }
        }

        public IEnumerable<UserFriend> UserFriends
        {
            get
            {
                return context.UserFriends.ToList();
            }
        }

        public IEnumerable<Comment> Comments
        {
            get
            {
                return context.Comments.Include("User").Include("Post").ToList();
            }
        }

        public void Add<T>(T entity) where T : ImageSharing.Data.Entity.Entity
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : ImageSharing.Data.Entity.Entity
        {
            this.context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
