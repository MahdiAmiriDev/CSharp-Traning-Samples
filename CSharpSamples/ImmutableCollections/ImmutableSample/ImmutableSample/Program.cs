


using System.Collections.Immutable;

var immutableCollection = ImmutableList.Create<int>(1, 2, 3, 4);

var dynamicList = immutableCollection.Add(5);

Console.WriteLine("orgingal immutable" + string.Join(",",immutableCollection));

Console.WriteLine("dynamic immutable" + string.Join(",", dynamicList));

Console.ReadKey();
