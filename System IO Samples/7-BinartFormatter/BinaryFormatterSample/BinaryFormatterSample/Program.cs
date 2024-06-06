
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Unicode;

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "binaryFormatter.txt");

if (!File.Exists(path))
{
    using (FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        //BinaryFormatter binaryFormatter = new BinaryFormatter();

        //binaryFormatter.Serialize(fs, new Person() { FirstName = "Mahdi", LastName = "Amiri", NationalCode = 44 });

        JsonSerializer.Serialize(fs, new Person() { FirstName = "Mahdi", LastName = "امیری", NationalCode = 44 },
            new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
            });
        
        fs.Close();
        fs.Dispose();
    }
}
else
{
    using (FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        //byte[] buffer = new byte[fs.Length];

        //var file = fs.Read(buffer, 0, buffer.Length);

        var person = JsonSerializer.Deserialize<List<Person>>(fs,new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        });

        foreach (var item in person)
        {
            //Console.WriteLine(item.NationalCode + " " + item.FirstName + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(item.LastName)) + "\n");
            var test = Encoding.UTF8.GetString(Encoding.Default.GetBytes(item.LastName));
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(test);
        }
        
        Console.ReadKey();
    }
}
public class Person
{
    public int NationalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}