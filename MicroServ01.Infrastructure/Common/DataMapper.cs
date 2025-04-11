using System.Data.Common;

namespace MicroServ01.Infrastructure.Common
{
    public static class DataMapper
    {
        public static T MapRecord<T>(DbDataReader dr) where T : new()
        {
            var obj = new T();
            var propiedades = typeof(T).GetProperties();            
            var colsNombres = new HashSet<string>();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                colsNombres.Add(dr.GetName(i));
            }

            foreach (var prop in propiedades)
            {
                if (colsNombres.Contains(prop.Name))
                {
                    var value = dr[prop.Name];

                    if (value != DBNull.Value)
                    {
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }

            return obj;
        }
    }
}
