
using System.Reflection;

var assembly = Assembly.LoadFrom(@"E:\Ef Core Learning And Traning\execption\Attribute\Sample.Domain\bin\Debug\net6.0\Sample.Domain.dll");

var types = assembly.GetTypes();

Console.WriteLine(assembly.FullName);

foreach(var type in types)
{
    Console.WriteLine($"{type.Name}");
}

Console.ReadLine();