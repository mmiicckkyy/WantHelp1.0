﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class PerfilController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Perfil/

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        //
        // GET: /Perfil/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Perfil/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Perfil/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Perfil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Perfil/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(usuario);
        }

        //
        // GET: /Perfil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Perfil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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