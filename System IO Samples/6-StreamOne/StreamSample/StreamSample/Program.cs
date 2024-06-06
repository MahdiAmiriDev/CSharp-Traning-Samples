

using System.Text;

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Strem.txt");

if (!File.Exists(path))
{

    using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite,
        1024,FileOptions.None))
    {
        byte[] byteArray = new byte[1024];

        byteArray = Encoding.UTF8.GetBytes("سلام نمونه فایل ایجاد شده با استفاده از استریم");

        //byte[] data = Encoding.UTF8.GetBytes("fuck sami low");


       //var text = new UTF8Encoding(true).GetBytes("نمونه دوم");

        fs.Write(byteArray, 0, byteArray.Length);
        //fs.Write(text, 0, text.Length);
        fs.SetLength(100000);
        fs.Close();
        fs.Dispose();
    }
}

Console.WriteLine(char.ConvertFromUtf32(23));
Console.WriteLine(char.ConvertToUtf32("Mahdi", 0));
Console.ReadKey();