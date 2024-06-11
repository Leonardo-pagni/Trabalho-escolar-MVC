using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace app_financas.Models
{
    public class Emprestimo : Root
    {

        public string vlrEmprestimoString { get; set; }
        public decimal vlrEmprestimo { get; set; }
        public decimal vlrJuros { get; set; }


        public Emprestimo()
        {
            v_pr_inclui = "pr_emprestimo_inclui";
        }
        public void carregar()
        {
            DataSet dsEmprestimo = new DataSet("dsEmprestimo");

            dsEmprestimo = (DataSet)Connection.CallDataBase("pr_emprestimo_seleciona", new object[] { 1 });

            vlrEmprestimo = (decimal)dsEmprestimo.Tables[0].Rows[0]["vlrEmprestimo"];
            vlrJuros = (decimal)dsEmprestimo.Tables[0].Rows[0]["vlrJuros"];
        }

    }
}