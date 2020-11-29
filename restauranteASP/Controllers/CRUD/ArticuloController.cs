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
    public class ArticuloController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        public Articulo_ convert(Articulo m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            Articulo_ p = (Articulo_)serializer.Deserialize(new JTokenReader(json), typeof(Articulo_));
            return p;
        }

        // GET: Articulo
        public ActionResult Index()
        {
            var articulo = db.Articulo.Include(a => a.Categoria).Include(a => a.UnidadMedida);

            List<Articulo> articulos = articulo.ToList();

            List<Articulo_> mesas_ = new List<Articulo_>();
            articulos.ForEach(m => mesas_.Add(convert(m)));

            return View(mesas_);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(convert(articulo));
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descipcion");
            ViewBag.idUnidadMedida = new SelectList(db.UnidadMedida, "idUnidadMedida", "descipcion");
            return View();
        }

        // POST: Articulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticulo,descipcion,precio,cantidad,sku,fechaIngreso,fechaCaducidad,idCategoria,idUnidadMedida,idProveedor,tarifaImpuesto")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descipcion", articulo.idCategoria);
            ViewBag.idUnidadMedida = new SelectList(db.UnidadMedida, "idUnidadMedida", "descipcion", articulo.idUnidadMedida);
            return View(convert(articulo));
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descipcion", articulo.idCategoria);
            ViewBag.idUnidadMedida = new SelectList(db.UnidadMedida, "idUnidadMedida", "descipcion", articulo.idUnidadMedida);
            return View(convert(articulo));
        }

        // POST: Articulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArticulo,descipcion,precio,cantidad,sku,fechaIngreso,fechaCaducidad,idCategoria,idUnidadMedida,idProveedor,tarifaImpuesto")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descipcion", articulo.idCategoria);
            ViewBag.idUnidadMedida = new SelectList(db.UnidadMedida, "idUnidadMedida", "descipcion", articulo.idUnidadMedida);
            return View(convert(articulo));
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(convert(articulo));
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
