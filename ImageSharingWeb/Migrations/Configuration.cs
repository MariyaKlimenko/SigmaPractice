namespace ImageSharing.Migrations
{
    using ImageSharing.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ImageSharing.Data.ImageSharingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImageSharing.Data.ImageSharingContext context)
        {
            
            User u1 = new User { ID = 1, FirstName = "Maria", SecondName = "Klimenko", Email = "maria@gmail.com", Password = "123456", Role = 0, IsActive = true };
            User u2 = new User { ID = 2, FirstName = "Alina", SecondName = "Fomenko", Email = "alina@gmail.com", Password = "123456", Role = 0, IsActive = true };
            User u3 = new User { ID = 3, FirstName = "Sebastian", SecondName = "Stan", Email = "stan@gmail.com", Password = "123456", Role = 0, IsActive = true };
            User u4 = new User { ID = 4, FirstName = "Matt", SecondName = "Bellamy", Email = "matt@gmail.com", Password = "123456", Role = 0, IsActive = true };

            context.Users.AddOrUpdate(x => x.ID,
                u1, u2, u3, u4        
              );

            context.UserFriends.AddOrUpdate(x => x.ID,
                new UserFriend { ID = 1, UserID = 1, FriendID = 2 },
                new UserFriend { ID = 2, UserID = 1, FriendID = 3 },
                new UserFriend { ID = 3, UserID = 1, FriendID = 4 },
                new UserFriend { ID = 4, UserID = 2, FriendID = 3 },
                new UserFriend { ID = 5, UserID = 2, FriendID = 4 },
                new UserFriend { ID = 6, UserID = 3, FriendID = 4 }
              );

            Post p1 = new Post { ID = 1, Image = "MyPHOTO_1.jpeg", Description = "Violet", CreatedAt = DateTime.Now, User = u1 };
            Post p2 = new Post { ID = 2, Image = "MyPHOTO_2.jpg", Description = "", CreatedAt = DateTime.Now, User = u1 };
            Post p3 = new Post { ID = 3, Image = "MyPHOTO_3.jpg", Description = "Pacific", CreatedAt = DateTime.Now, User = u1 };
            Post p4 = new Post { ID = 4, Image = "MyPHOTO_4.jpeg", Description = "", CreatedAt = DateTime.Now, User = u2 };
            Post p5 = new Post { ID = 5, Image = "MyPHOTO_5.jpg", Description = "No comments", CreatedAt = DateTime.Now, User = u2 };
            Post p6 = new Post { ID = 6, Image = "MyPHOTO_6.jpg", Description = "Green", CreatedAt = DateTime.Now, User = u2 };
            Post p7 = new Post { ID = 7, Image = "MyPHOTO_7.jpg", Description = "", CreatedAt = DateTime.Now, User = u3 };
            Post p8 = new Post { ID = 8, Image = "MyPHOTO_8.jpg", Description = "", CreatedAt = DateTime.Now, User = u3 };
            Post p9 = new Post { ID = 9, Image = "MyPHOTO_9.jpg", Description = "Endless", CreatedAt = DateTime.Now, User = u3 };
            Post p10 = new Post { ID = 10, Image = "MyPHOTO_10.jpg", Description = "", CreatedAt = DateTime.Now, User = u3 };

            context.Posts.AddOrUpdate(x => x.ID, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 );

            Comment c1 = new Comment { ID = 1, User = u1, Post = p10, Commentary = "Very nice", CreatedAt = DateTime.Now };
            Comment c2 = new Comment { ID = 2, User = u1, Post = p5, Commentary = "Cool", CreatedAt = DateTime.Now };
            Comment c3 = new Comment { ID = 3, User = u2, Post = p6, Commentary = "Like it", CreatedAt = DateTime.Now };
            Comment c4 = new Comment { ID = 4, User = u2, Post = p1, Commentary = "Good", CreatedAt = DateTime.Now };
            Comment c5 = new Comment { ID = 5, User = u3, Post = p1, Commentary = "Really good", CreatedAt = DateTime.Now };
            Comment c6 = new Comment { ID = 6, User = u4, Post = p2, Commentary = "Like", CreatedAt = DateTime.Now };

            context.Comments.AddOrUpdate(x => x.ID, c1, c2, c3, c4, c5, c6);

        }
    }
}
