using ImageSharing.Business;
using ImageSharing.Data;
using ImageSharing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSharing.Controllers
{
    public class FriendController : Controller
    {
        UserFriendHelper helper = new UserFriendHelper(new Repository());

        //
        // GET: /Friends/

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create(int friendid)
        {
            try
            {
                int myid = (int)Session["userID"];
                helper.AddFriend(myid, friendid);
                return RedirectToAction("Profile", "Profile", new { profileID = friendid });
            }
            catch
            {
                return RedirectToAction("Friends", "Home");
            }
        }

        public ActionResult Delete(int friendid)
        {
            int myid = (int)Session["userID"];
            UserFriend uf = helper.GetUserFriend(myid, friendid);
            helper.DeleteFriend(uf.ID);
            return RedirectToAction("Profile", "Profile", new { profileID = friendid });
        }

    }
}
