using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAzureBlog.DAL;
using MyAzureBlog.Models;
using System.Data.Entity;

// ypala 17.01.2015
namespace MyAzureBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        BlogContext context = new BlogContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View(context.Comments.ToList());
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            context.Configuration.LazyLoadingEnabled = true;
            Comment c = context.Comments.SingleOrDefault(t => t.Id == id);
            return View(c);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            try
            {
                context.Entry(comment).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index","Comment");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
