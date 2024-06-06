


FileSystemWatcher fileSystemWatcher = new("C:\\")
{
    NotifyFilter = NotifyFilters.LastWrite,
    Filter = "*.*",
    EnableRaisingEvents = false,
    IncludeSubdirectories = true,

};

fileSystemWatcher.Changed += FileChange;



void FileChange(object sender, FileSystemEventArgs e)
{
    Console.WriteLine(e.Name);
}

Console.ReadKey();