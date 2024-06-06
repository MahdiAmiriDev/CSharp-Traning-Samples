using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample.DiscoveringMetaData
{
    public class MetaDataPrinter
    {
        private readonly Type _type;

        public MetaDataPrinter(Type type)
        {
            _type = type;
        }

        public void Print()
        {
            PrintMaintInfo();
            PrintMethodInfo();
            PrintPropertyInfo();
            PropertyFieldInfo();

        }

        private void PropertyFieldInfo()
        {
            Console.WriteLine($"##### Fields information of Type {_type.Name}");
            var fieldInfos = _type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                Console.WriteLine($"{fieldInfo.Name} {fieldInfo.FieldType}");
            }
        }

        private void PrintPropertyInfo()
        {
            Console.WriteLine($"##### Properties information of Type {_type.Name}");

            var properties = _type.GetProperties();
            foreach (var item in properties)
            {
                Console.WriteLine($"{item.PropertyType} {item.Name}");
            }
        }

        private void PrintMethodInfo()
        {
            Console.WriteLine($"##### Method information of Type {_type.Name}");
            var methodInfo = _type.GetMethods();
            foreach (var method in methodInfo)
            {
                Console.WriteLine($"{method.Name}(");
                var parameters = method.GetParameters();
                foreach (var parameter in parameters)
                {
                    Console.WriteLine($"{parameter.Name} {parameter.ParameterType}");
                }

                Console.WriteLine(")");
            }
        }

        private void PrintMaintInfo()
        {
            Console.WriteLine($"##### information of Type {_type.Name}");
            Console.WriteLine($"full name{_type.FullName}");
            Console.WriteLine($"assembly name{_type.AssemblyQualifiedName}");
            Console.WriteLine($"name space {_type.Namespace}");
            Console.WriteLine($"is abstract {_type.IsAbstract}");
            Console.WriteLine($"is enum {_type.IsEnum}");
            Console.WriteLine($"is public{_type.IsNotPublic}");                       
        }
    }
}
