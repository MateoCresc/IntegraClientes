using ClienteApp.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ClienteAppDBContext _clienteAppDBContext;
        public HomeController(ClienteAppDBContext db) {
            _clienteAppDBContext = db;
        
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public JsonResult Get()
        //{
        //    return Json(ClienteAppDBContext.Clientes, JsonRequestBehavior.AllowGet);
        //}
    }
}