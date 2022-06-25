using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManager.Repository;
using TaskManager.Model;

namespace TaskManager.Controllers
{
    public class FunctionsController : Controller
    {
        private readonly CDBContext dbContext = new CDBContext();

        // GET: Departments
        public ActionResult Index()
        {
            return View(dbContext.Functions.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = dbContext.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FunctionName,DepartmentID,CreatedBy")] Function function)
        {
            if (ModelState.IsValid)
            {
                dbContext.Functions.Add(function);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(function);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = dbContext.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FunctionName,DepartmentID,CreatedBy")] Function function)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(function).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(function);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = dbContext.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Function function = dbContext.Functions.Find(id);
            dbContext.Functions.Remove(function);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
