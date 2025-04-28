using ClienteApp.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ClienteApp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteAppDBContext _clienteAppDBContext;
        public ClienteController(ClienteAppDBContext db)
        {
            _clienteAppDBContext = db;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_clienteAppDBContext.Clientes.ToList());
        }
        
        // GET: Cliente/List
        public ActionResult List()
        {
            return View(_clienteAppDBContext.Clientes.ToList());
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Cliente/Details
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = _clienteAppDBContext.Clientes.Find(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente clienteDTO)
        {
            if (ModelState.IsValid)
            {
                var clienteEncontrado = _clienteAppDBContext.Clientes.Any(x => x.Cuit == clienteDTO.Cuit);
                if (!clienteEncontrado)
                {
                    Data.Models.Cliente clienteBD = new Data.Models.Cliente
                    {
                        Cuit = clienteDTO.Cuit,
                        Activo = clienteDTO.Activo,
                        Direccion = clienteDTO.Direccion,
                        RazonSocial = clienteDTO.RazonSocial,
                        Telefono = clienteDTO.Telefono 
                    };

                    _clienteAppDBContext.Clientes.Add(clienteBD);
                    _clienteAppDBContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(clienteDTO);
        }

        // GET: Cliente/Edit
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = _clienteAppDBContext.Clientes.Find(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Edit/11
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteExistente = _clienteAppDBContext.Clientes.Find(cliente.Cuit);

                if (clienteExistente == null)
                {
                    return HttpNotFound();
                }

                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Activo = cliente.Activo;

                _clienteAppDBContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = _clienteAppDBContext.Clientes.Find(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/DeleteConfirmed/11
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var cliente = _clienteAppDBContext.Clientes.Find(id);
            _clienteAppDBContext.Clientes.Remove(cliente);
            _clienteAppDBContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<JsonResult> GetRazonSocialByCuit(string cuit)
        {
            var http = new HttpClient();
            var texto = await http.GetStringAsync(
                $"https://sistemaintegracomex.com.ar/Account/GetNombreByCuit?cuit={cuit}"
            );
            if (texto == "@nombre")
            {
                texto = string.Empty;
            }

            return Json(texto, JsonRequestBehavior.AllowGet);
        }

    }
}