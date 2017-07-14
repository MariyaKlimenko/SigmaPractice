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
    public class CommentController : Controller
    {
        CommentHelper helper = new CommentHelper(new Repository());
        //
        // GET: /Comment/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(string Commentary, int User, int Post)
        {
            try
            {
                helper.AddComment(Commentary, Post, User);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Friends", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int commentId)
        {
            int myid = (int)Session["userID"];
            helper.DeleteComment(commentId);
            return RedirectToAction("Index", "Home");
        }

    }
}
