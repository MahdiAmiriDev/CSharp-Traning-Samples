

var drives = DriveInfo.GetDrives();

foreach (var drive in drives)
{
    if (drive.IsReady)
    {
        string result = $"drive name : {drive.Name} \n drive totalSpace : {((drive.TotalSize / 1024) / 1024)} \n" +
                $"Free Space:{((drive.TotalFreeSpace / 1024) / 1024)} \n Root:{drive.RootDirectory} \n" +
                $"Lable:{drive.VolumeLabel}";

        Console.WriteLine(result);
    }

}

Console.ReadLine();