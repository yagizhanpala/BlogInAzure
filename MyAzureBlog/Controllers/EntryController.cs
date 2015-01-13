using MyAzureBlog.DAL;
using MyAzureBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAzureBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EntryController : Controller
    {
        BlogContext context = new BlogContext();

        // GET: Entry
        public ActionResult Index()
        {
            return View();
        }

        // GET: Entry/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Entry e = context.Entries.SingleOrDefault(t => t.Id == id);
                ViewBag.Content = e.Content;
                return View(e);
            }
            catch
            {
                return RedirectToAction("Index","Entry");
            }
        }

        // GET: Entry/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(context.Categories, "Id", "Name");
            return View();
        }

        // POST: Entry/Create
        [HttpPost]
        public ActionResult Create(Entry entry, int Category_Id)
        {
            try
            {
                entry.Category = context.Categories.SingleOrDefault(t => t.Id == Category_Id);
                entry.Date = DateTime.Now;
                context.Entries.Add(entry);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Category_Id = new SelectList(context.Categories, "Id", "Name");
                Response.Write(ex);
                return View();
            }
        }

        // GET: Entry/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Entry e = context.Entries.SingleOrDefault(t => t.Id == id);
                ViewBag.Category_Id = new SelectList(context.Categories, "Id", "Name",e.Category);
                return View(e);
            }
            catch
            {
                return RedirectToAction("../Index");
            }
        }

        // POST: Entry/Edit/5
        [HttpPost]
        public ActionResult Edit(Entry entry, int id, int Category_Id)
        {
            try
            {
                // 05.12.2014 ypala V1.1
                entry.Category = context.Categories.SingleOrDefault(t => t.Id == Category_Id);
                context.Entry(entry).State = EntityState.Modified;
                context.SaveChanges();

                return Redirect("/Entry/Edit/"+id);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Entry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entry/Delete/5
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


        // 11.12.2014 AngularJS
        public JsonResult List()
        {
            List<Entry> entries = context.Entries.OrderByDescending(t=> t.Id).ToList();
            return Json(entries, JsonRequestBehavior.AllowGet);
        }

    }
}
