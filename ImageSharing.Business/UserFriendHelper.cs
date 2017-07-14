using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.Business
{
    public class UserFriendHelper
    {
        private IRepository context;
        private UserHelper userhelper;

        public UserFriendHelper(IRepository repository)
        {
            this.context = repository;
            this.userhelper = new UserHelper(this.context);
        }

        public UserFriend AddFriend(int userid, int friendid)
        {
            var f = new UserFriend { UserID = userid, FriendID = friendid };
            context.Add(f);
            context.SaveChanges();
            return f;
        }

        public void DeleteFriend(int id)
        {
            var f = GetUserFriend(id);
            context.Delete(f);
            context.SaveChanges();
        }

        public IEnumerable<UserFriend> GetFriends()
        {
            return context.UserFriends.ToList();
        }

        public IEnumerable<User> GetMyFriends(int userid)
        {
            List<UserFriend> myUserFriends = context.UserFriends.Where(x => x.UserID != null && x.UserID == userid).ToList();
            List<User> myFriends = new List<User>();
            foreach (var item in myUserFriends)
            {
                myFriends.Add(userhelper.GetUser(item.FriendID));
            }
            return myFriends;
        }

        public UserFriend GetUserFriend(int id)
        {
            return GetFriends().First(x => x.ID == id);
        }

        public UserFriend GetUserFriend(int userid, int friendid)
        {
            return GetFriends().First(x => x.UserID == userid && x.FriendID == friendid);
        }

    }
}
