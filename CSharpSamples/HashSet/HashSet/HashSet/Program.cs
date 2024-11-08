


using System.Threading.Channels;

var hashSet = new HashSet<int>(Enumerable.Range(1, 6));

hashSet.Add(7);

Console.WriteLine(string.Join(",",hashSet));

hashSet.Add(6);

Console.WriteLine(string.Join(",", hashSet));

Console.ReadKey();