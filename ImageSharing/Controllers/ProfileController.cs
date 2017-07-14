using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageSharing.Models;
using ImageSharing.Business;
using ImageSharing.Data;
using ImageSharing.Data.Entity;


namespace ImageSharing.Controllers
{
    public class ProfileController : Controller
    {

        UserHelper helper = new UserHelper(new Repository());
        PostHelper posthelper = new PostHelper(new Repository());
        CommentHelper commenthelper = new CommentHelper(new Repository());
        UserFriendHelper friendhelper = new UserFriendHelper(new Repository());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {

            return View(new User());
        }

        public ActionResult Login()
        {

            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User m)
        {

            User user = helper.Login(m.Email, m.Password);

            if (user != null)
            {
                Session["userID"] = user.ID;
                Session["userFirstName"] = user.FirstName;
                Session["userSecondName"] = user.SecondName;
                Session["userEmail"] = user.Email;
                return RedirectToAction("Profile", "Profile", new { profileID = user.ID });
            }
            else
            {
                return RedirectToAction("ErrorLogin", "Profile");
            }

        }

        public ActionResult ErrorLogin()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["userID"] = null;
            Session["userFirstName"] = null;
            Session["userSecondName"] = null;
            Session["userEmail"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(User m)
        {
            try
            {
                m.Role = 0;
                m.IsActive = true;
                User user = helper.AddUser(m.FirstName, m.SecondName, m.Email, m.Password, m.Role, m.IsActive);
                if (user != null)
                {
                    Session["userID"] = user.ID;
                    Session["userFirstName"] = user.FirstName;
                    Session["userSecondName"] = user.SecondName;
                    Session["userEmail"] = user.Email;
                }
                return RedirectToAction("Profile", "Profile", new { profileID = user.ID });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Profile()
        {
            int id = (int)Session["userID"];
            List<PostCommentModel> pcm = new List<PostCommentModel>();
            IEnumerable<Post> posts = new List<Post>();
            posts = posthelper.GetMyPosts(id);
            foreach (var item in posts)
            {
                pcm.Add(new PostCommentModel() { Post = item, Comments = commenthelper.GetPostComments(item.ID) });
            }
            ImageSharingViewModel model = new ImageSharingViewModel();
            model.Posts = pcm;
            model.ProfileUser = helper.GetUser(id);
            model.Friends = friendhelper.GetMyFriends(id);

            ViewBag.Message = "You";
            return View(model);
        }

        [HttpGet]
        public ActionResult Profile(int profileId)
        {
            ImageSharingViewModel model = new ImageSharingViewModel();

            if (Session["userID"] != null)
            {
                int myid = (int)Session["userID"];
                model.Friends = friendhelper.GetMyFriends(myid);

                if (profileId != myid)
                {
                    foreach (var item in model.Friends)
                    {
                        if (item.ID == profileId)
                        {
                            model.IsFriend = true;
                        }
                    }
                }
            }
            List<PostCommentModel> pcm = new List<PostCommentModel>();
            IEnumerable<Post> posts = posthelper.GetMyPosts(profileId);
            foreach (var item in posts)
            {
                pcm.Add(new PostCommentModel() { Post = item, Comments = commenthelper.GetPostComments(item.ID) });
            }

            model.Posts = pcm;
            model.ProfileUser = helper.GetUser(profileId);


            ViewBag.Message = "You";
            return View(model);
        }

    }
}
