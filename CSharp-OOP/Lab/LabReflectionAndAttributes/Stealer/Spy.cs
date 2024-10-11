using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] @public = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] nonPublic = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }

            foreach (MethodInfo item in @public.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }

            foreach (MethodInfo item in nonPublic.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string name, params string[] fields)
        {
            Type classType = Type.GetType(name);

            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {name}");

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base class: {type.BaseType.Name}");

            foreach (MethodInfo item in methods)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods((BindingFlags)60);

            foreach (var item in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} will return {item.ReturnType}");
            }

            foreach (var item in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
