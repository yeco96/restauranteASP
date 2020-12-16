using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using restauranteASP;

namespace restauranteASP.Controllers.CRUD
{
    public class PedidoController : Controller
    {
        private restauranteEntities db = new restauranteEntities();


        [HttpPost]
        public JsonResult buscarCliente(String identificacion)
        {
            Cliente cliente = new Cliente();

            if (identificacion == null)
            {
                cliente = new Cliente();
                cliente.nombreCompleto = "EL CLIENTE NO EXISTE";
                return Json(cliente, JsonRequestBehavior.AllowGet);
            }
            cliente = db.Cliente.Find(identificacion);
            if (cliente == null)
            {
                cliente = new Cliente();
                cliente.nombreCompleto = "EL CLIENTE NO EXISTE";
                return Json(cliente, JsonRequestBehavior.AllowGet);
            }

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            try
            {
                var pedido = db.Pedido.Include(p => p.PedidoEstado);

                List<Pedido> pedidos = pedido.ToList();

                List<Pedido_> Pedido_ = new List<Pedido_>();
                pedidos.ForEach(p => Pedido_.Add(convert(p)));

                return View(Pedido_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Pedidos", "Create"));
            }
        }

        public Pedido_ convert(Pedido m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            Pedido_ p = (Pedido_)serializer.Deserialize(new JTokenReader(json), typeof(Pedido));
            return p;
        }
        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(convert(pedido));
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario");
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombreCompleto");
            ViewBag.idMesa = new SelectList(db.Mesa, "idMesa", "descripcion");
            ViewBag.idEstado = new SelectList(db.PedidoEstado, "idPedidoEstado", "descripcion");
            ViewBag.usuario = new SelectList(db.Usuario, "usuario1", "contrasena");
            return View();
        }

        // POST: Pedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedido,idCliente,observacion,numeroFactura,idMesa,idEstado,idCaja,usuario,subTotal,descuento,impuesto,total")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", pedido.idCaja);
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombreCompleto", pedido.idCliente);
            ViewBag.idMesa = new SelectList(db.Mesa, "idMesa", "descripcion", pedido.idMesa);
            ViewBag.idEstado = new SelectList(db.PedidoEstado, "idPedidoEstado", "descripcion", pedido.idEstado);
            ViewBag.usuario = new SelectList(db.Usuario, "usuario1", "contrasena", pedido.usuario);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", pedido.idCaja);
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombreCompleto", pedido.idCliente);
            ViewBag.idMesa = new SelectList(db.Mesa, "idMesa", "descripcion", pedido.idMesa);
            ViewBag.idEstado = new SelectList(db.PedidoEstado, "idPedidoEstado", "descripcion", pedido.idEstado);
            ViewBag.usuario = new SelectList(db.Usuario, "usuario1", "contrasena", pedido.usuario);
            return View(convert(pedido));
        }

        // POST: Pedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedido,idCliente,observacion,numeroFactura,idMesa,idEstado,idCaja,usuario,subTotal,descuento,impuesto,total")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", pedido.idCaja);
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombreCompleto", pedido.idCliente);
            ViewBag.idMesa = new SelectList(db.Mesa, "idMesa", "descripcion", pedido.idMesa);
            ViewBag.idEstado = new SelectList(db.PedidoEstado, "idPedidoEstado", "descripcion", pedido.idEstado);
            ViewBag.usuario = new SelectList(db.Usuario, "usuario1", "contrasena", pedido.usuario);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {

            try {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Pedido pedido = db.Pedido.Find(id);
                if (pedido == null)
                {
                    return HttpNotFound();
                }
                return View(convert(pedido));

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Pedido", "Create"));
            }

        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

        try {
                Pedido pedido = db.Pedido.Find(id);
                db.Pedido.Remove(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");

        }
        catch (Exception ex)
        {
                return View("Error", new HandleErrorInfo(ex, "Pedido", "Create"));
        }

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
