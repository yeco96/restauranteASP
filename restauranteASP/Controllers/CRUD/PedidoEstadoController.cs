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
    public class PedidoEstadoController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: PedidoEstado
        public ActionResult Index()
        {
            try
            {
                var pedidoEstado = db.PedidoEstado.Include(m => m.Pedido);

                List<PedidoEstado> pedidoE = pedidoEstado.ToList();

                List<PedidoEstado_> PedidoEstado_ = new List<PedidoEstado_>();
                pedidoE.ForEach(m => PedidoEstado_.Add(convert(m)));

                return View(PedidoEstado_);
            }
            catch (Exception ex)
            {       
                return View("Error", new HandleErrorInfo(ex, "PedidoEstado", "Create"));
            }
        }

        public PedidoEstado_ convert(PedidoEstado m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            PedidoEstado_ p = (PedidoEstado_)serializer.Deserialize(new JTokenReader(json), typeof(PedidoEstado_));
            return p;
        }
            
        

        // GET: PedidoEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoEstado pedidoEstado = db.PedidoEstado.Find(id);
            if (pedidoEstado == null)
            {
                return HttpNotFound();
            }
            return View(convert(pedidoEstado));
        }

        // GET: PedidoEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoEstado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoEstado,descripcion")] PedidoEstado pedidoEstado)
        {
            if (ModelState.IsValid)
            {
                db.PedidoEstado.Add(pedidoEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedidoEstado);
        }

        // GET: PedidoEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoEstado pedidoEstado = db.PedidoEstado.Find(id);
            if (pedidoEstado == null)
            {
                return HttpNotFound();
            }
            return View(convert(pedidoEstado));
        }

        // POST: PedidoEstado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoEstado,descripcion")] PedidoEstado pedidoEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedidoEstado);
        }

        // GET: PedidoEstado/Delete/5
        public ActionResult Delete(int? id)
     {
        try {
                
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoEstado pedidoEstado = db.PedidoEstado.Find(id);
            if (pedidoEstado == null)
            {
                return HttpNotFound();
            }
            return View(convert(pedidoEstado));
        }
        catch (Exception ex)
        {
                return View("Error", new HandleErrorInfo(ex, "PedidoEstado", "Create"));
        }

      }

        // POST: PedidoEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PedidoEstado pedidoEstado = db.PedidoEstado.Find(id);
                db.PedidoEstado.Remove(pedidoEstado);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "PedidoEstado", "Create"));
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
