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
namespace restauranteASP.Controllers
{
    public class MaestroDetallePedidoController : Controller
    {
        private  restauranteEntities db = new restauranteEntities();

        // GET: MaestroDetallePedido
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {

            var detalle = db.Pedido
                .Include(p=>p.Cliente)
                .Include(p=>p.PedidoDetalle).Where(p=>p.idCliente== "aixcujdbd").ToList();

            ViewBag.estados = db.PedidoEstado.ToList();
            return View(detalle);
        }
        [HttpPost]
        public ActionResult Index(Dictionary<string,object> pedido )
        {
            //var record=db.Pedido.SingleOrDefault(p => p.idPedido.ToString() == pedido["PedidoEstado"];
            //if (record != null)
            //{
            //    record.idEstado=pedido;
            //}

            var detalle = db.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.PedidoDetalle).Where(p => p.idCliente == "aixcujdbd").ToList();

            return View(detalle);
        }
       
    }
}