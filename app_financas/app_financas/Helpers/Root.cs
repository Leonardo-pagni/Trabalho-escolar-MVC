using DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class Root : Base
{
    protected string v_pr_inclui;

    public virtual void Adicionar()
    {
        Connection.CallDataBase(v_pr_inclui, new object[] { GerarXml(this), 1 });
    }

    // return DataBase.Methods.DataTableToList<Pagina>(((DataSet)retorno).Tables[0]);

    public virtual string GerarXml(object objeto)
    {
        StringWriter st = new StringWriter();
        XmlWriter writer = new XmlTextWriter(st);

        writer.WriteStartElement("xml");
        writer.WriteStartElement("dados" + objeto.GetType().Name.ToLower());
        writer.WriteStartElement(objeto.GetType().Name.ToLower());

        var propriedadesDaClasse = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        for (int i = 0; i < propriedadesDaClasse.Length; i++)
        {
            if (Connection.MinValueToNull(propriedadesDaClasse[i].GetValue(this)) != null)
            {
                EscreverAtributo(writer, propriedadesDaClasse[i].Name.ToLower(), propriedadesDaClasse[i].GetValue(this));
            }
        }

        //fazer todas as propriedades.
        //existe algum IEnumerable? Se sim, pega e itera.

        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();

        return st.ToString();
    }
}

