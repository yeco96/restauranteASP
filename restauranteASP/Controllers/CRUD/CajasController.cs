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
    public class CajasController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: Cajas
        public ActionResult Index()
        {
            try
            {
                var Caja = db.Caja.Include(m => m.CajaMovimiento);

                List<Caja> Cajas = Caja.ToList();

                List<Caja_> Cajas_ = new List<Caja_>();
                Cajas.ForEach(m => Cajas_.Add(convert(m)));

                return View(Cajas_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
            }
        }

        public Caja_ convert(Caja m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            Caja_ p = (Caja_)serializer.Deserialize(new JTokenReader(json), typeof(Caja_));
            return p;
        }

        // GET: Cajas/Details/5
        public ActionResult Details(int? id)
        {
            try {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Caja caja = db.Caja.Find(id);
                if (caja == null)
                {
                    return HttpNotFound();
                }
                return View(convert(caja));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
            }
        }    

        // GET: Cajas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cajas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCaja,fechaApertura,fechaCierre,fondo,usuario")] Caja caja)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Caja.Add(caja);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(caja);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
            }
        }

        // GET: Cajas/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Caja caja = db.Caja.Find(id);
                if (caja == null)
                {
                    return HttpNotFound();
                }
                return View(convert(caja));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
            }
        }

        // POST: Cajas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCaja,fechaApertura,fechaCierre,fondo,usuario")] Caja caja)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(caja).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(convert(caja));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
            }
        }

        // GET: Cajas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Caja caja = db.Caja.Find(id);
                if (caja == null)
                {
                    return HttpNotFound();
                }
                return View(convert(caja));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }


        }


        // POST: Cajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Caja caja = db.Caja.Find(id);
                db.Caja.Remove(caja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cajas", "Create"));
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
