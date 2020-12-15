using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restauranteASP.Controllers
{
    public class CajaController : Controller
    {
        private restauranteEntities db = new restauranteEntities();
        // GET: Caja
        public ActionResult Pago()
        {
            try
            {
                var mesa = db.Mesa;

                List<Mesa> mesas = mesa.ToList();

                List<Mesa_> mesas_ = new List<Mesa_>();
                mesas.ForEach(m => mesas_.Add(convert(m)));

                return View();
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

        



            
        
    }
}