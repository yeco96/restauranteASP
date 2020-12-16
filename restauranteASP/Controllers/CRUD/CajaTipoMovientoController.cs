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
    public class CajaTipoMovientoController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: CajaTipoMoviento
        public ActionResult Index()
        {
            try
            {
                var cajatipo = db.CajaTipoMoviento;

                List<CajaTipoMoviento> cajatipos = cajatipo.ToList();

                List<CajaTipoMoviento_> cajaTipoMoviento_ = new List<CajaTipoMoviento_>();
                cajatipos.ForEach(m => cajaTipoMoviento_.Add(convert(m)));

                return View(cajaTipoMoviento_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }
        }

        public CajaTipoMoviento_ convert(CajaTipoMoviento m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            CajaTipoMoviento_ p = (CajaTipoMoviento_)serializer.Deserialize(new JTokenReader(json), typeof(CajaTipoMoviento_));
            return p;
        }


        // GET: CajaTipoMoviento/Details/5
        public ActionResult Details(int? id)
        {
            try { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaTipoMoviento cajaTipoMoviento = db.CajaTipoMoviento.Find(id);
                if (cajaTipoMoviento == null)
                {
                    return HttpNotFound();
                }

                return View(convert(cajaTipoMoviento));
           
            }
             catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }
        }
    

        // GET: CajaTipoMoviento/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }
        }

        // POST: CajaTipoMoviento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCajaMovimiento,descripcion")] CajaTipoMoviento cajaTipoMoviento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CajaTipoMoviento.Add(cajaTipoMoviento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(cajaTipoMoviento);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }

        }

        // GET: CajaTipoMoviento/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaTipoMoviento cajaTipoMoviento = db.CajaTipoMoviento.Find(id);
                if (cajaTipoMoviento == null)
                {
                    return HttpNotFound();
                }
              
                return View(convert(cajaTipoMoviento));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }
        }

        // POST: CajaTipoMoviento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCajaMovimiento,descripcion")] CajaTipoMoviento cajaTipoMoviento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cajaTipoMoviento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
       
                return View(convert(cajaTipoMoviento));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }

        }

        // GET: CajaTipoMoviento/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CajaTipoMoviento cajaTipoMoviento = db.CajaTipoMoviento.Find(id);
                if (cajaTipoMoviento == null)
                {
                    return HttpNotFound();
                }
                return View(convert(cajaTipoMoviento));
          
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
            }
        }

        // POST: CajaTipoMoviento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CajaTipoMoviento cajaTipoMoviento = db.CajaTipoMoviento.Find(id);
                db.CajaTipoMoviento.Remove(cajaTipoMoviento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "CajaTipoMoviento", "Create"));
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
