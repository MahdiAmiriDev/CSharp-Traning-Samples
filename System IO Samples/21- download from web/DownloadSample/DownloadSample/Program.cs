

using System.ComponentModel;
using System.Net;
using System.Text;
using System.Web;

string address = "https://xx.sahand-music.ir/Archive/L/Leila%20Foruhar/Leila%20Forouhar%20-%20Sarab/01%20Yare%20Shirin.mp3";

string fileSavedAddress = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "g+\\music\\");

fileSavedAddress += Path.GetFileName(address);

WebClient wc = new WebClient();

wc.DownloadProgressChanged += DownloadChage;
wc.DownloadFileCompleted += DownloadComplete;

wc.DownloadFile(address,fileSavedAddress);

void DownloadComplete(object? sender, AsyncCompletedEventArgs e)
{
    Console.WriteLine("done");
}

void DownloadChage(object sender, DownloadProgressChangedEventArgs e)
{
    Console.WriteLine(e.ProgressPercentage);
}