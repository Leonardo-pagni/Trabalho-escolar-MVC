using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class Base
{
    public static void EscreverAtributo(XmlWriter writer, string nomeAtributo, object variavel)
    {
        if (variavel != null)
        {
            switch (Type.GetTypeCode(variavel.GetType()))
            {
                case TypeCode.Boolean:
                    EscreverAtributoBoolean(writer, nomeAtributo, (bool)variavel);
                    break;

                case TypeCode.Double:
                    EscreverAtributoDouble(writer, nomeAtributo, (double)variavel);
                    break;

                case TypeCode.Decimal:
                    EscreverAtributoDecimal(writer, nomeAtributo, (decimal)variavel);
                    break;

                case TypeCode.Int32:
                    EscreverAtributoInt(writer, nomeAtributo, (int)variavel);
                    break;

                case TypeCode.Int64:
                    EscreverAtributoLong(writer, nomeAtributo, (long)variavel);
                    break;

                case TypeCode.DateTime:
                    EscreverAtributoDateTime(writer, nomeAtributo, (DateTime)variavel);
                    break;

                case TypeCode.String:
                default:
                    EscreverAtributoString(writer, nomeAtributo, variavel.ToString());
                    break;
            }
        }
    }

    private static void EscreverAtributoBoolean(XmlWriter writer, string nomeAtributo, bool valor)
    {
        writer.WriteAttributeString(nomeAtributo, XmlConvert.ToString(valor ? 1 : 0));
    }

    private static void EscreverAtributoDouble(XmlWriter writer, string nomeAtributo, double valor)
    {
        if (valor != double.MinValue)
        {
            writer.WriteAttributeString(nomeAtributo, XmlConvert.ToString(valor));
        }
    }

    private static void EscreverAtributoDecimal(XmlWriter writer, string nomeAtributo, decimal valor)
    {
        if (valor != decimal.MinValue)
        {
            writer.WriteAttributeString(nomeAtributo, XmlConvert.ToString(valor));
        }
    }

    private static void EscreverAtributoInt(XmlWriter writer, string nomeAtributo, int valor)
    {
        if (valor != int.MinValue)
        {
            writer.WriteAttributeString(nomeAtributo, XmlConvert.ToString(valor));
        }
    }

    private static void EscreverAtributoLong(XmlWriter writer, string nomeAtributo, long valor)
    {
        if (valor != long.MinValue)
        {
            writer.WriteAttributeString(nomeAtributo, XmlConvert.ToString(valor));
        }
    }

    private static void EscreverAtributoDateTime(XmlWriter writer, string nomeAtributo, DateTime valor)
    {
        if (valor != DateTime.MinValue)
        {
            writer.WriteAttributeString(nomeAtributo, valor.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
    }

    private static void EscreverAtributoString(XmlWriter writer, string nomeAtributo, string valor)
    {
        string str = valor.Replace("'", "´").Replace("\"", " ");

        if (!string.IsNullOrEmpty(str))
        {
            writer.WriteAttributeString(nomeAtributo, str);
        }
    }
}

