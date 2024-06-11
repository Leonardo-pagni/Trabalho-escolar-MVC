using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app_financas.Models;
using System.Web.Mvc;

namespace app_financas.Controllers
{
    public class HistoricoController : Controller
    {
         public ActionResult Index()
         {
             return View();
         }

        [HttpPost]

        public ActionResult carrega()
        {
            Historico historico= new Historico();

            historico.carregar();

            ViewBag.Email = historico.email;
            ViewBag.tipoHistorico = historico.tipoHistorico;
            ViewBag.dataAlteracao = historico.dataAlteracao;

            return View("Index"); 
        }

    }
}
