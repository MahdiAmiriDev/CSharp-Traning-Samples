
using System.Diagnostics;
using System.Text;

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RWS.txt");

using FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

StreamReader StreamReader = new StreamReader(fs, Encoding.UTF8);

StreamWriter StreamWriter = new StreamWriter(fs, Encoding.Default);

while (true)
{
    var input = Console.ReadLine();
    switch (input.ToLower())
    {
        case "read":
            Console.WriteLine(StreamReader.ReadToEnd());
            break;
        case "write":
            StreamWriter.Write("test for write");
            StreamWriter.Flush();
            break;
        case "end":
            Process.GetCurrentProcess().Kill();
            break;
    }
}