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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var invoiceProxy = new InvoicesProxy(baseUrl);
            var model = invoiceProxy.getOData(new OdataModel() { id = id });
            if (!model.Any())
            {
                ViewBag.Error = "No existe el formulario";
                return RedirectToAction("List");
            }

            return View(model.FirstOrDefault());
        }


        [HttpPost]
        public ActionResult Index(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index");

            var invoiceProxy = new InvoicesProxy(baseUrl);
            if (!invoiceProxy.post(model))
            {
                ViewBag.Error = "No es posible crear un formulario, por favor revise";
                return View("Index");
            }
            ViewBag.Success = $"Formulario creado con éxito, su radicado es: {model.FormNumber}";

            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var invoiceProxy = new InvoicesProxy(baseUrl);
            if (!invoiceProxy.put(model.FormNumber, model))
            {
                ViewBag.Error = "No es posible editar un formulario, por favor revise";
                return View(model);
            }
            ViewBag.Success = $"Fue editado con éxito";

            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            var invoiceProxy = new InvoicesProxy(baseUrl);
            var result = invoiceProxy.get().Where(it => it.OrderState == 1);

            return View(result);
        }

        [HttpPost]
        public ActionResult ListOdata(OdataModel model)
        {
            var invoiceProxy = new InvoicesProxy(baseUrl);
            var result = invoiceProxy.getOData(model);

            return Json(result);
        }

        [HttpGet]
        public ActionResult deleteForm(string id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            
            var invoiceProxy = new InvoicesProxy(baseUrl);
            IEnumerable<InvoiceViewModel> list;
            if (!invoiceProxy.delete(id))
            {
                ViewBag.Error = "No es posible eliminar un formulario, por favor revise";
                list = invoiceProxy.get();
                return RedirectToAction("List", list);
            }
            list = invoiceProxy.get();
            return RedirectToAction("List", list);
        }

    }
}