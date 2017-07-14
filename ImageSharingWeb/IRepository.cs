using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.Data.Entity;
using System.Data.Entity;



namespace ImageSharing
{
    public interface IRepository 
    {
        IEnumerable <Post> Posts { get; }
        IEnumerable <User> Users { get; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<UserFriend> UserFriends { get; }


        void Add<T>(T entity) where T : ImageSharing.Data.Entity.Entity;

        void Delete<T>(T entity) where T : ImageSharing.Data.Entity.Entity;

        void SaveChanges();
    }
}
