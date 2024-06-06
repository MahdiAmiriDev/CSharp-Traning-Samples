



using System.Reflection;

var assembly = Assembly.LoadFrom(@"E:\Ef Core Learning And Traning\execption\Attribute\Sample.Domain\bin\Debug\net6.0\Sample.Domain.dll");

var personType = assembly.GetType("Sample.Domain.Person");

var person = Activator.CreateInstance(personType);

var printMethod = personType.GetMethod("Print");

printMethod.Invoke(person, null);


Console.WriteLine(person);

