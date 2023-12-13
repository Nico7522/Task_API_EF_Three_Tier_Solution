using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.DAL.Utils
{
    internal static class Method
    {
        internal static void UpdateEntity<T>(T oldValues, T newValues, params string[] propertiesToUpdate)
        {
            if (propertiesToUpdate is null || propertiesToUpdate.Length == 0)
            {
                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(newValues);
                    property.SetValue(oldValues, value);
                }
            } else
            {
                foreach (var property in propertiesToUpdate)
                {
                    var propertyToUpdate = typeof(T).GetProperty(property);
                    if (propertyToUpdate is not null)
                    {
                        var value = propertyToUpdate.GetValue(newValues);
                        propertyToUpdate.SetValue(oldValues, value);
                    }
                }
            }
        }
    }
}
