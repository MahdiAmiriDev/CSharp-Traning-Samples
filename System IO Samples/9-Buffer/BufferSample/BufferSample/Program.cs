

using System.Text;

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "buffer.txt");

using FileStream fs = new(path,FileMode.Open);

BufferedStream bufferedStream = new BufferedStream(fs);
//bufferedStream.Seek(0, SeekOrigin.Begin);
bufferedStream.Write(new UTF8Encoding().GetBytes("hello buffer one \n"));
//fs.Write(new UTF8Encoding().GetBytes("hello mahdi"));
bufferedStream.Close();
fs.Close();
bufferedStream.Dispose();
fs.Dispose();