using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class CursosController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Cursos/

        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        //
        // GET: /Cursos/Details/5

        public ActionResult Details(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cursos/Create

        [HttpPost]
        public ActionResult Create(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cursos);
        }

        //
        // GET: /Cursos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Edit/5

        [HttpPost]
        public ActionResult Edit(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}