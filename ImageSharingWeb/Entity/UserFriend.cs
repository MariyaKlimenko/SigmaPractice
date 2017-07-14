using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.Data.Entity
{
    public class UserFriend : Entity
    {
        public int UserID { get; set; }
        public int FriendID { get; set; }

    }
}
