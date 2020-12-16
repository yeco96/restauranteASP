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
    public class RolsController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: Rols
        public ActionResult Index() { 
          try
            {
                var rol = db.Rol;

        List<Rol> rols = rol.ToList();

        List<Rol_> rols_ = new List<Rol_>();
        rols.ForEach(m => rols_.Add(convert(m)));
        
                return View(rols_);
    }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }
        }

        public Rol_ convert(Rol m)
{
    JsonSerializer serializer = new JsonSerializer();
    JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
    Rol_ p = (Rol_)serializer.Deserialize(new JTokenReader(json), typeof(Rol_));
    return p;
}


        // GET: Rols/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rol rol = db.Rol.Find(id);
                if (rol == null)
                {
                    return HttpNotFound();
                }

                return View(convert(rol));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }
        }

        // GET: Rols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rols/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRol,descripcion")] Rol rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Rol.Add(rol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(rol);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }
        }

        // GET: Rols/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rol rol = db.Rol.Find(id);
                if (rol == null)
                {
                    return HttpNotFound();
                }
                return View(rol);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }

        }

        // POST: Rols/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRol,descripcion")] Rol rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(rol).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
              
                return View(convert(rol));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }
        }

        // GET: Rols/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rol rol = db.Rol.Find(id);
                if (rol == null)
                {
                    return HttpNotFound();
                }
       
                return View(convert(rol));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
            }
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Rol rol = db.Rol.Find(id);
                db.Rol.Remove(rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Rols", "Create"));
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
