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
    public class CajaMovimientoController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: CajaMovimiento
        public ActionResult Index()
        {
            try
            {
                var cajaMovimiento = db.CajaMovimiento.Include(c => c.Caja).Include(c => c.CajaTipoMoviento);

                List<CajaMovimiento> cajaMovimientos = cajaMovimiento.ToList();

                List<CajaMovimiento_> cajaMovimiento_ = new List<CajaMovimiento_>();
                cajaMovimientos.ForEach(c => cajaMovimiento_.Add(convert(c)));

                return View(cajaMovimiento_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        public CajaMovimiento_ convert(CajaMovimiento c)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(c));
            CajaMovimiento_ p = (CajaMovimiento_)serializer.Deserialize(new JTokenReader(json), typeof(CajaMovimiento_));
            return p;
        }
        // GET: CajaMovimiento/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaMovimiento cajaMovimiento = db.CajaMovimiento.Find(id);
                if (cajaMovimiento == null)
                {
                    return HttpNotFound();
                }
                return View(convert(cajaMovimiento));
             
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        // GET: CajaMovimiento/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario");
                ViewBag.idTipoMoviento = new SelectList(db.CajaTipoMoviento, "idCajaMovimiento", "descripcion");
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        // POST: CajaMovimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCaja,secuencia,idTipoMoviento,idTipoMedioPago,monto")] CajaMovimiento cajaMovimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CajaMovimiento.Add(cajaMovimiento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", cajaMovimiento.idCaja);
                ViewBag.idTipoMoviento = new SelectList(db.CajaTipoMoviento, "idCajaMovimiento", "descripcion", cajaMovimiento.idTipoMoviento);
                return View(cajaMovimiento);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        // GET: CajaMovimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaMovimiento cajaMovimiento = db.CajaMovimiento.Find(id);
                if (cajaMovimiento == null)
                {
                    return HttpNotFound();
                }
                ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", cajaMovimiento.idCaja);
                ViewBag.idTipoMoviento = new SelectList(db.CajaTipoMoviento, "idCajaMovimiento", "descripcion", cajaMovimiento.idTipoMoviento);
                return View(cajaMovimiento);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        // POST: CajaMovimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCaja,secuencia,idTipoMoviento,idTipoMedioPago,monto")] CajaMovimiento cajaMovimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cajaMovimiento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.idCaja = new SelectList(db.Caja, "idCaja", "usuario", cajaMovimiento.idCaja);
                ViewBag.idTipoMoviento = new SelectList(db.CajaTipoMoviento, "idCajaMovimiento", "descripcion", cajaMovimiento.idTipoMoviento);
                return View(convert(cajaMovimiento));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }

        }

        // GET: CajaMovimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaMovimiento cajaMovimiento = db.CajaMovimiento.Find(id);
                if (cajaMovimiento == null)
                {
                    return HttpNotFound();
                }

                return View(convert(cajaMovimiento));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
            }
        }

        // POST: CajaMovimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CajaMovimiento cajaMovimiento = db.CajaMovimiento.Find(id);
                db.CajaMovimiento.Remove(cajaMovimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaMovimiento", "Create"));
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
