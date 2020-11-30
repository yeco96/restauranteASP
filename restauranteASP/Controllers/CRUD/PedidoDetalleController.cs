using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using restauranteASP;

namespace restauranteASP.Controllers.CRUD
{
    public class PedidoDetalleController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: PedidoDetalle
        public ActionResult Index()
        {
            try {
                 
                var pedidoDetalle = db.PedidoDetalle.Include(p => p.Articulo).Include(p => p.Pedido);

                List<PedidoDetalle> pedidosD = pedidoDetalle.ToList();

                List<PedidoDetalle_> PedidoDetalle_ = new List<PedidoDetalle_>();
                pedidosD.ForEach(p => PedidoDetalle_.Add(convert(p)));

                return View(PedidoDetalle_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Pedidos", "Create"));

            }
        }
        public PedidoDetalle_ convert(PedidoDetalle m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            PedidoDetalle_ p = (PedidoDetalle_)serializer.Deserialize(new JTokenReader(json), typeof(PedidoDetalle));
            return p;
        }

        // GET: PedidoDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            return View(convert(pedidoDetalle));
        }

        // GET: PedidoDetalle/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "descipcion");
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idCliente");
            return View();
        }

        // POST: PedidoDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedido,idArticulo,secuencia,precioUnitario,cantidad,subTotal,porcentajeDescuento,impuesto,total")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.PedidoDetalle.Add(pedidoDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "descipcion", pedidoDetalle.idArticulo);
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idCliente", pedidoDetalle.idPedido);
            return View(convert(pedidoDetalle));
        }

        // GET: PedidoDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "descipcion", pedidoDetalle.idArticulo);
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idCliente", pedidoDetalle.idPedido);
            return View(convert(pedidoDetalle));
        }

        // POST: PedidoDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedido,idArticulo,secuencia,precioUnitario,cantidad,subTotal,porcentajeDescuento,impuesto,total")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "descipcion", pedidoDetalle.idArticulo);
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idCliente", pedidoDetalle.idPedido);
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalle/Delete/5
        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
                if (pedidoDetalle == null)
                {
                    return HttpNotFound();
                }
                return View(convert(pedidoDetalle));

            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "PedidoDetalle", "Create"));

            }
        }

        // POST: PedidoDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         try{
                PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
                db.PedidoDetalle.Remove(pedidoDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");

         } 
         catch(Exception ex) 
         {

                return View("Error", new HandleErrorInfo(ex, "PedidoDetalle", "Create"));

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
