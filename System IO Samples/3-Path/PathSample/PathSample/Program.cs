// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var currentDirectory = Environment.CurrentDirectory;

var myCreatedFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"SampleTextFile.txt");

if(!File.Exists(myCreatedFile))
    File.Create(myCreatedFile);

var customPath = Path.Join("D:\\","Movies");
Console.WriteLine(customPath);

Console.WriteLine(Path.GetTempPath());
Console.WriteLine(Path.GetDirectoryName(myCreatedFile));
Console.WriteLine(Path.GetExtension(myCreatedFile));
Console.WriteLine(Path.GetFileName(myCreatedFile));
Console.WriteLine("d");

var name = File.ReadAllText(myCreatedFile);

var allWordInFile = name.Split(' ');

if (name.Contains("nikamooz.ir"))
{
    var newText = name.Replace("nikamooz.ir", "mahdiDev.ir");
    File.WriteAllText(myCreatedFile, newText);
}
    