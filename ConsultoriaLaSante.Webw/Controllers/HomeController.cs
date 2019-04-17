using ConsultoriaLaSante.Web.Models;
using ConsultoriaLaSante.Web.Proxies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultoriaLaSante.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseUrl;
        public HomeController()
        {
            baseUrl = ConfigurationManager.AppSettings["baseUrl"] ?? throw new ArgumentException("No hay creada una llave en el config 'baseUrl'");
        }
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

            var invoiceProxy = new InvoicesProxy(baseUrl);
            if (!invoiceProxy.post(model))
            {
                ViewBag.Error = "No es posible crear un formulario, por favor revise";
                return RedirectToAction("Index");
            }
            ViewBag.Success = $"Formulario creado con éxito, su radicado es: {model.formData}";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult List()
        {
            var invoiceProxy = new InvoicesProxy(baseUrl);
            var result = invoiceProxy.getOData();

            return View(result);
        }

        [HttpPost]
        public ActionResult ListOdata(OdataModel model)
        {
            var invoiceProxy = new InvoicesProxy(baseUrl);
            var result = invoiceProxy.getOData(model);

            return Json(result);
        }

    }
}