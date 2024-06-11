using app_financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app_financas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Home home = new Home();

            home.carregar();

            ViewBag.Credito = home.Credito;
            ViewBag.debito = home.Debito;

            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Pagina de contatos";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

      


        [HttpPost]
    
        public ActionResult cadastro()
        {
            Home home = new Home();

            home.Email = Request["email"];
            home.Senha = Request["senha"];
            home.Cpf = Request["cpf"];

            home.Adicionar();

            return Redirect("/Home/Index");
        }

        public ActionResult entrar()
        {
            Home home = new Home();

            home.Email = Request["email"];
            home.Senha = Request["senha"];

            home.entrar();

            return Redirect("/Home/Index");

        }
    }
}