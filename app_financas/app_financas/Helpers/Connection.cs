using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataBase
{
    public class Connection
    {
        private static string SqlConnection()
        {
            return ConfigurationManager.AppSettings["sqLConn"];
        }

        public static object CallDataBase(string spName, params object[] parameters)
        {
            object retorno = new object();

            using (SqlConnection connection = new SqlConnection(SqlConnection()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandTimeout = int.MaxValue,
                    CommandText = spName,
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlCommandBuilder.DeriveParameters(command);

                if (parameters != null && parameters.Length > 0)
                {
                    for (int i = 0; i < command.Parameters.Count; i++)
                    {
                        if (command.Parameters[i].ParameterName.Equals("@RETURN_VALUE"))
                            continue;

                        command.Parameters[i].Value = MinValueToNull(parameters[i - 1]);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);

                retorno = ds;
            }

            return (object)retorno;
        }

        public static object MinValueToNull(object valor)
        {
            if (valor == null) return null;

            Type tipo = valor.GetType();

            if (tipo.IsValueType)
            {
                object valorPadrao = Activator.CreateInstance(tipo);
                if (valor.Equals(valorPadrao)) return null;
            }
            else if (tipo == typeof(string) && string.IsNullOrEmpty((string)valor))
            {
                return null;
            }

            return valor;
        }
    }
}
