using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Domain.Utils
{
    public static class ReflectionUtils
    {
        public static IEnumerable<Type> GetTypes<T>(string scope = "Assessment")
        {
            var typeToFind = typeof(T);

            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();

            return assembliesToScan.Where(i => i.FullName.StartsWith(scope))
                .SelectMany(s => s.GetTypes())
                .Where(p => typeToFind.IsAssignableFrom(p) && !p.IsAbstract);
        }
    }
}
