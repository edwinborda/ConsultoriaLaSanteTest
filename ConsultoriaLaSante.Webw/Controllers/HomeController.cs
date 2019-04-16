using ConsultoriaLaSante.Web.Models;
using ConsultoriaLaSante.Web.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultoriaLaSante.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateForm(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var invoiceProxy = new InvoicesProxy();
            if (!invoiceProxy.post(model))
            {
                ViewBag.Error = "No es posible crear un formulario, por favor revise";
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

    }
}