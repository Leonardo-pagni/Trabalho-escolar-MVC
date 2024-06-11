using app_financas.Helpers;
using DataBase;
using System;
using System.Data;
using System.Web.Helpers;

namespace app_financas.Models
{
    public class Home : Root
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set; }
        public decimal Junho { get; set; }
        public decimal Julho { get; set; }
        public decimal Agosto { get; set; }
        public decimal Setembro { get; set; }
        public decimal Outubro { get; set; }
        public decimal Novembro { get; set; }

        public Home()
        {
            v_pr_inclui = "pr_usuario_inclui";
        }

        public void entrar()
        {

            DataSet dsUsuarios = new DataSet("dsUsuarios");

            // Cria uma nova instância do DataTable
            DataTable dtUsuario = new DataTable("dtUsuario");

            // Adiciona a coluna 'senha'
            DataColumn senhaColumn = new DataColumn("senha", typeof(string));
            dtUsuario.Columns.Add(senhaColumn);

            // Adiciona a coluna 'email'
            DataColumn emailColumn = new DataColumn("email", typeof(string));
            dtUsuario.Columns.Add(emailColumn);

            // Adiciona o DataTable ao DataSet
            dsUsuarios.Tables.Add(dtUsuario);

            dsUsuarios = (DataSet)Connection.CallDataBase("pr_usuario_login", new object[] { Email, Senha, 1 });

         }

        public void carregar()
        {

            DataSet dsHome = new DataSet("dsHome");



            dsHome = (DataSet)Connection.CallDataBase("pr_index_seleciona", new object[] { 1 });

            Credito = (decimal)dsHome.Tables[0].Rows[0]["vlrCredito"];
            Debito = (decimal)dsHome.Tables[0].Rows[0]["vlrdebito"];
        }
    }
}
