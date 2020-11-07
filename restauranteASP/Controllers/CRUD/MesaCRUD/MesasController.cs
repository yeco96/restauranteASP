using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using restauranteASP;

namespace restauranteASP.Controllers.CRUD.MesaCRUD
{
    public class MesasController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: Mesas
        public ActionResult Index()
        {
            var mesa = db.Mesa.Include(m => m.MesaEstado);
            return View(mesa.ToList());
        }

        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion");
            return View();
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMesa,descripcion,idEstado,capacidadPersona")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Mesa.Add(mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion", mesa.idEstado);
            return View(mesa);
        }

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion", mesa.idEstado);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMesa,descripcion,idEstado,capacidadPersona")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion", mesa.idEstado);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesa mesa = db.Mesa.Find(id);
            db.Mesa.Remove(mesa);
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
