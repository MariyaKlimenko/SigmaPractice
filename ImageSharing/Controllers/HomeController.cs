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
    public class HomeController : Controller
    {

        PostHelper helper = new PostHelper(new Repository());
        CommentHelper commenthelper = new CommentHelper(new Repository());
        UserHelper userhelper = new UserHelper(new Repository());
        UserFriendHelper friendhelper = new UserFriendHelper(new Repository());

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ImageSharingViewModel model = new ImageSharingViewModel();
            List<PostCommentModel> pcm = new List<PostCommentModel>();
            IEnumerable<Post> posts;
            if (Session["userID"] != null)
            {
                int myid = (int)Session["userID"];
                model.Friends = friendhelper.GetMyFriends(myid);
                posts = helper.GetMyFriendsPosts(model.Friends, myid);

            }
            else
            {
                posts = helper.GetPosts();
            }

            foreach (var item in posts)
            {
                pcm.Add(new PostCommentModel() { Post = item, Comments = commenthelper.GetPostComments(item.ID) });
            }
            model.Posts = pcm;
            model.Post = new Post();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Friends()
        {
            int myid = (int)Session["userID"];

            IEnumerable<User> model = friendhelper.GetMyFriends(myid);

            return View(model);
        }
        [HttpPost]
        public ActionResult Search(string search)
        {
            IEnumerable<User> users = userhelper.SearchUser(search);
            /*List<User> result = new List<User>();

            foreach (var item in users)
            {
                string fullname = item.FirstName + " " + item.SecondName;
                if (s.Contains(fullname))
                {
                    result.Add(item);
                }
            }*/
            return View(users);
        }
    }
}
