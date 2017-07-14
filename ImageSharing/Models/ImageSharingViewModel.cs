using System;
using System.Collections.Generic;
using System.Linq;
using ImageSharing.Data.Entity;
using System.Web;

namespace ImageSharing.Models
{
    public class ImageSharingViewModel
    {
        public Post Post { get; set; }
        public User ProfileUser { get; set; }
        public IEnumerable<PostCommentModel> Posts { get; set; }
        public IEnumerable<UserFriend> UserFriends { get; set; }
        public IEnumerable<User> Friends { get; set; }
        public Boolean IsFriend { get; set; }


        public ImageSharingViewModel()
        {
            this.IsFriend = false;
            this.Post = new Post();
            this.ProfileUser = new User();
            this.Posts = new List<PostCommentModel>();
            this.UserFriends = new List<UserFriend>();
            this.Friends = new List<User>();

        }

    }

}