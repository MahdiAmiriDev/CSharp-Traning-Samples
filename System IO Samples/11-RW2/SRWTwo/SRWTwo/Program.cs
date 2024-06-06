

using System.Text;


StringBuilder sb = new();

StringWriter sw = new StringWriter();

sw.WriteLine("hello");
sw.WriteLine("mahdi");
sw.WriteLine("amiri");
sw.WriteLine(1223788);




var writeToStream = sw.ToString();


