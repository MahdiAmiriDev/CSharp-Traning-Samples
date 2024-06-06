

using System.Text;

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "claire.png");
var clone  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "cloneClaire.png");

if (!File.Exists(path))
{
    var stringToByte = new UTF8Encoding().GetBytes("hello m f");

    MemoryStream ms = new MemoryStream(stringToByte,0, stringToByte.Length);
    //x-sher
    StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

    sw.WriteLine();
}

//var image = File.ReadAllBytes(path);
//using var memory = new MemoryStream(image);
//int result = 0;
//string line = string.Empty;
//while (memory.CanRead)
//{
//    line += memory.ReadByte();
//}

//Console.WriteLine(line);

//عکسو میخونه بایت می کنه کپی می کنه تو مموری استریم و سپس رایت می کند 
using FileStream fStream = new(clone,FileMode.Create);
var claireData = File.ReadAllBytes(path);
MemoryStream cloneMemoryStream = new(claireData, true);
cloneMemoryStream.WriteTo(fStream);
fStream.Close();
fStream.Dispose();

Console.ReadKey();