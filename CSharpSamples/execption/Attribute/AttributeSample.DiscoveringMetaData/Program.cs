
using AttributeSample.DiscoveringMetaData;
using Sample.Domain;

var intPrinter = new MetaDataPrinter(typeof(int));

var personPrinter = new MetaDataPrinter(typeof(Person));

intPrinter.Print();
Console.WriteLine("press to print persin metedata");
Console.ReadKey();
Console.Clear();
personPrinter.Print();