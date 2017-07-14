using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Data.Entity;

namespace ImageSharing.Business
{
    public class PostHelper
    {

        private IRepository context;
        private UserHelper users;

        public PostHelper(IRepository repository)
        {
            this.context = repository;
            this.users = new UserHelper(this.context);
        }

        public Post AddPost(string image, string description, int userid)
        {
            var d = new Post() { Image = image, Description = description, CreatedAt = DateTime.Now };
            d.User = users.GetUser(userid);
            context.Add(d);
            context.SaveChanges();
            return d;
        }

        public void DeletePost(int id)
        {
            var d = GetPost(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public Post EditPost(int id, string image, string description)
        {
            var d = GetPost(id);
            d.Image = image;
            d.Description = description;
            context.Add(d);
            context.SaveChanges();
            return d;
        }

        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> ps = context.Posts.OrderByDescending(post => post.CreatedAt);
            return ps.ToList();
        }

        public IEnumerable<Post> GetMyFriendsPosts(IEnumerable<User> friends, int myid)
        {
            List<Post> myfriendsposts = new List<Post>();
            foreach (var friend in friends)
            {
                IEnumerable<Post> p = GetMyPosts(friend.ID);
                foreach (var item in p)
                {
                    myfriendsposts.Add(item);
                }
            }
            IEnumerable<Post> myposts = GetMyPosts(myid);
            foreach (var item in myposts)
            {
                myfriendsposts.Add(item);
            }

            IEnumerable<Post> result = myfriendsposts.OrderByDescending(post => post.CreatedAt);
            return result;
        }

        public IEnumerable<Post> GetMyPosts(int userid)
        {
            IEnumerable<Post> ps = context.Posts.OrderByDescending(post => post.CreatedAt);
            return ps.Where(x => x.User != null && x.User.ID == userid).ToList();
        }


        public Post GetPost(int id)
        {
            return GetPosts().First(x => x.ID == id);
        }
    }
}
