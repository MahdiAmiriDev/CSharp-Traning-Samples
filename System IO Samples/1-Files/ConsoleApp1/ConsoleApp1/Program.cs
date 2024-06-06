

if (!File.Exists(@"C:\Users\pc\Desktop\IOFIles\myFile.txt"))
        File.Create(@"C:\Users\pc\Desktop\IOFIles\myFile.txt");



File.AppendAllText(@"C:\Users\pc\Desktop\IOFIles\myFile.txt", "hello this is test file \n");

var innerText = File.ReadAllText(@"C:\Users\pc\Desktop\IOFIles\myFile.txt");

Console.WriteLine(innerText);

Console.WriteLine("\n");

File.SetAttributes(@"C:\Users\pc\Desktop\IOFIles\myFile.txt", FileAttributes.Normal | FileAttributes.Archive);

File.Copy(@"C:\Users\pc\Desktop\IOFIles\myFile.txt", @"C:\Users\pc\Desktop\IOFIles\copy\newVersion.txt");

FileInfo fileInfo = new(@"C:\Users\pc\Desktop\IOFIles\myFile.txt");

Console.WriteLine(fileInfo.FullName);
Console.WriteLine(fileInfo.Extension);
Console.WriteLine(fileInfo.Directory);
Console.WriteLine(fileInfo.CreationTime);
Console.WriteLine(fileInfo.LastAccessTime);