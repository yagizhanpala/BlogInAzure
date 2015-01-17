using MyAzureBlog.DAL;
using MyAzureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAzureBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext context = new BlogContext();

        // GET: Home
        public ActionResult Index(string controller)
        {
            return View(context.Entries.Where(t=>t.Published == true).OrderByDescending(t=> t.Id).ToList());
        }

        public ActionResult Read(string seourl)
        {
            try
            {
                Entry entry = context.Entries.SingleOrDefault(t => t.Published == true && t.SeoUrl == seourl);
                // Entry için yapılan commentleri çektik 16.01.2015 ypala
                entry.Comment = context.Comments.Where(t => t.Entry.Id == entry.Id && t.Published == true).ToList();
                ViewBag.Content = entry.Content;
                return View(entry);
            }
            catch (Exception)
            {
                return Redirect("/");
            }
            
        }

        // AngularJs kullanarak Comment ekledim ypala 16.01.2015
        public JsonResult AddComment(Comment c, int entryId)
        {
            c.Entry = context.Entries.Single(t=> t.Id == entryId);
            c.Date = DateTime.Now;
            c.Published = false;
            context.Comments.Add(c);
            context.SaveChanges();
            return Json("ok");
        }



        // 14.02.2014 AngularJS ypala
        public JsonResult List()
        {
            var entries = context.Entries.OrderByDescending(t=> t.Id).Where(t => t.Published == true).Select(t => new { t.SeoUrl, t.Title }).ToList();
            return Json(entries, JsonRequestBehavior.AllowGet);
        }
    }
}