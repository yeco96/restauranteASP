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

namespace restauranteASP.Controllers.CRUD.MesaCRUD
{
    public class MesasController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: Mesas
        public ActionResult Index()
        {
            try
            {
                var mesa = db.Mesa.Include(m => m.MesaEstado);

                List<Mesa> mesas = mesa.ToList();

                List<Mesa_> mesas_ = new List<Mesa_>();
                mesas.ForEach(m => mesas_.Add(convert(m)));
        
                return View(mesas_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }
        }

        public Mesa_ convert(Mesa m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            Mesa_ p = (Mesa_)serializer.Deserialize(new JTokenReader(json), typeof(Mesa_));
            return p;
        }


        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            try
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

                return View(convert(mesa));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion");
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMesa,descripcion,idEstado,capacidadPersona")] Mesa mesa)
        {
            try
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
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }

        }

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
                return View(convert(mesa));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMesa,descripcion,idEstado,capacidadPersona")] Mesa mesa)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(mesa).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.idEstado = new SelectList(db.MesaEstado, "idMesaEstado", "descripcion", mesa.idEstado);
                return View(convert(mesa));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }

        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
                return View(convert(mesa));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
            }

        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                Mesa mesa = db.Mesa.Find(id);
                db.Mesa.Remove(mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Create"));
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
