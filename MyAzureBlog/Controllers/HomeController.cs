﻿using MyAzureBlog.DAL;
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
                ViewBag.Description = entry.Description;
                ViewBag.Content = entry.Content;
                return View(entry);
            }
            catch (Exception)
            {
                return Redirect("/");
            }
            
        }

        // 14.02.2014 AngularJS ypala
        public JsonResult List()
        {
            var entries = context.Entries.OrderByDescending(t=> t.Id).Where(t => t.Published == true).Select(t => new { t.SeoUrl, t.Title }).ToList();
            return Json(entries, JsonRequestBehavior.AllowGet);
        }
    }
}