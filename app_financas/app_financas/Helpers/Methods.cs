using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace app_financas.Helpers
{
    public class Methods
    {
        public static List<T> DataTableToList<T>(DataTable table) where T : new()
        {
            var result = new List<T>();

            var columns = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName.ToLower()).ToList();

            foreach (DataRow row in table.Rows)
            {
                var objectItem = new T();

                result.Add(DataRowToObject(objectItem, row, columns));
            }

            return result;
        }

        public static T DataRowToObject<T>(T objectDefault, DataRow dr, List<string> columns)
        {
            var properties = objectDefault.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                try
                {
                    if (columns.Contains(property.Name.ToLower()))
                    {
                        var value = dr[property.Name];
                        if (value != DBNull.Value)
                        {
                            object convertedValue = null;

                            var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                            if (targetType.IsEnum)
                            {
                                convertedValue = Enum.ToObject(targetType, value);
                            }
                            else if (targetType.IsValueType || targetType == typeof(string))
                            {
                                convertedValue = Convert.ChangeType(value, targetType);
                            }

                            property.SetValue(objectDefault, convertedValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }

            return objectDefault;
        }
    }
}