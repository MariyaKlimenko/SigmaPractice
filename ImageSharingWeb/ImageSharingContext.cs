using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.Data
{
    public class ImageSharingContext : DbContext
    {
        public ImageSharingContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

    }
}
