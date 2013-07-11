﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;
using P.V.WantHelp_.Utils;
using WebMatrix.WebData;

namespace P.V.WantHelp_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            ViewBag.Message = "Cursos con Certificado de Profesionalidad";

            return View();
        }
        public ActionResult modificado()
        {
            ViewBag.Message = "Modify this MVC application.";

            return View();
        }

        public ActionResult modificado2()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
		public ActionResult MiCurso()
		{
			ViewBag.Message = "los cursos que se dan";

            return View();
		}
        public ActionResult About()
        {
            if (Request.IsAuthenticated)
            {
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.IsAuthenticated)
            {
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contacto()
        {
            ViewBag.Message = "Informaciones de nuestros cursos";
            return View();
        }
       
    }
}
