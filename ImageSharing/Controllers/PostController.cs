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
    public class PostController : Controller
    {

        PostHelper helper = new PostHelper(new Repository());
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(ImageSharingViewModel m, int User)
        {
            try
            {
                helper.AddPost(m.Post.Image, m.Post.Description, User);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Friends", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int postId)
        {
            int myid = (int)Session["userID"]; ;
            helper.DeletePost(postId);
            return RedirectToAction("Profile", "Profile", new { profileID = myid });
        }

    }
}
