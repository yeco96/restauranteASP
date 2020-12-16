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
    public class UsuariosController : Controller
    {
        private restauranteEntities db = new restauranteEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            try
            {
                var usuario = db.Usuario.Include(m => m.Rol);
                List<Usuario> usuarios = usuario.ToList();

                List<Usuario_> usuario_ = new List<Usuario_>();
                usuarios.ForEach(m => usuario_.Add(convert(m)));

                return View(usuario_);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuarios", "Create"));
            }
        }

        public Usuario_ convert(Usuario m)
        {
            JsonSerializer serializer = new JsonSerializer();
            JObject json = JObject.Parse(JsonConvert.SerializeObject(m));
            Usuario_ p = (Usuario_)serializer.Deserialize(new JTokenReader(json), typeof(Usuario_));
            return p;
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
          
            return View(convert(usuario));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuario", "Create"));
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuario1,contrasena,nombreCompleto")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuario", "Create"));
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(convert(usuario));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuario", "Create"));
            }
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuario1,contrasena,nombreCompleto")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuarios", "Create"));
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(convert(usuario));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuarios", "Create"));
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Usuario usuario = db.Usuario.Find(id);
                db.Usuario.Remove(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Usuarios", "Create"));
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
