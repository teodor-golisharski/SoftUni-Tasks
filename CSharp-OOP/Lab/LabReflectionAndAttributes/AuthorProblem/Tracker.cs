using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methodInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var item in methodInfo)
            {
                if(item.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);
                    
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{item.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
