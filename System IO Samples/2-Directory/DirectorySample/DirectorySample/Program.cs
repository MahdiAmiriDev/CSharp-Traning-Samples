

Directory.CreateDirectory(@"C:\Users\pc\Desktop\DTest\PHP");

if(Directory.Exists(@"C:\Users\pc\Desktop\DTest"))
{
    var directories = Directory.GetDirectories(@"C:\Users\pc\Desktop\DTest","*",SearchOption.AllDirectories);

    var files = Directory.GetFiles(@"C:\Users\pc\Desktop\DTest", "*", SearchOption.AllDirectories);

    foreach (var item in files)
    {
        Console.WriteLine(item);
    }

    DirectoryInfo directoryInfo = new(@"C:\Users\pc\Desktop\DTest");

    Console.WriteLine(directoryInfo.FullName);
    Console.WriteLine(directoryInfo.Extension);
    Console.WriteLine(directoryInfo.Root);
    Console.WriteLine(directoryInfo.Parent);
}