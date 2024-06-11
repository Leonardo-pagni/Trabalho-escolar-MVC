using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Helpers;

namespace app_financas.Models
{
    public class Historico
    {
        public string email { get; set; }
        public string tipoHistorico { get; set; }
        public DateTime dataAlteracao { get; set; }

        public void carregar()
        {


            DataSet dsHistorico = new DataSet("dsUsuarios");

            
            DataTable dtHistorico= new DataTable("dtUsuario");

            
            DataColumn senhaColumn = new DataColumn("email", typeof(string));
            dtHistorico.Columns.Add(senhaColumn);

            
            DataColumn emailColumn = new DataColumn("acao", typeof(string));
            dtHistorico.Columns.Add(emailColumn);


            DataColumn dataColumn = new DataColumn("dataAlteracao", typeof(DateTime));
            dtHistorico.Columns.Add(dataColumn);

            
            dsHistorico.Tables.Add(dtHistorico);

            dsHistorico = (DataSet)Connection.CallDataBase("pr_historico_seleciona", new object[] { 1 });

            email = (string)dsHistorico.Tables[0].Rows[0]["email"];
            tipoHistorico = (string)dsHistorico.Tables[0].Rows[0]["acao"];
            dataAlteracao = (DateTime)dsHistorico.Tables[0].Rows[0]["dataAlteracao"];

        }


    }
}