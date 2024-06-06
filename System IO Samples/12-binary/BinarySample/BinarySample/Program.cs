

var address = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "binary.txt");

FileStream fs = new FileStream(address, FileMode.OpenOrCreate, FileAccess.ReadWrite);

BinaryReader br = new BinaryReader(fs);
BinaryWriter bw = new BinaryWriter(fs);

//bw.Write("sample binary writer Developer");
//bw.Write(1403);

var reshteh = br.ReadString();

Console.WriteLine(reshteh);






fs.Dispose();
fs.Close();

