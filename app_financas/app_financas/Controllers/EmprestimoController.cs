using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app_financas.Models;
using System.Web.Mvc;


namespace app_financas.Controllers
{
    public class EmprestimoController : Controller
    {
        public  ActionResult Index()
        {
            Emprestimo emprestimo = new Emprestimo();

            emprestimo.carregar();

            ViewBag.vlrEmprestimo = emprestimo.vlrEmprestimo;

            ViewBag.vlrJuros = emprestimo.vlrJuros;

            return View();
        }

        public  ActionResult PegarEmprestimo()
        {
            return View();
        }

        public ActionResult cadastro()
        {
            decimal emprestimo1;
            Emprestimo emprestimo = new Emprestimo();

            emprestimo.vlrEmprestimoString = Request["emprestimo"];
            decimal.TryParse(emprestimo.vlrEmprestimoString, out emprestimo1);
            emprestimo.vlrEmprestimo = emprestimo1;
            emprestimo.vlrEmprestimoString = string.Empty;

            emprestimo.Adicionar();

            return Redirect("/Home/Index");
        }

    }
}
