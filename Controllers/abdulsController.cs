using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class abdulsController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: abduls
        public ActionResult Index(string searchString)
        {
            var abduls = from m in db.abduls
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                abduls = abduls.Where(s => s.Father_Name.Contains(searchString));
            }
            return View(abduls);
        }

        // GET: abduls/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            abdul abdul = db.abduls.Find(id);
            if (abdul == null)
            {
                return HttpNotFound();
            }
            return View(abdul);
        }

        // GET: abduls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: abduls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Father_Name,Marks,Garde")] abdul abdul)
        {
            if (ModelState.IsValid)
            {
                db.abduls.Add(abdul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abdul);
        }

        // GET: abduls/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            abdul abdul = db.abduls.Find(id);
            if (abdul == null)
            {
                return HttpNotFound();
            }
            return View(abdul);
        }

        // POST: abduls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Father_Name,Marks,Garde")] abdul abdul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abdul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abdul);
        }

        // GET: abduls/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            abdul abdul = db.abduls.Find(id);
            if (abdul == null)
            {
                return HttpNotFound();
            }
            return View(abdul);
        }

        // POST: abduls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            abdul abdul = db.abduls.Find(id);
            db.abduls.Remove(abdul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
