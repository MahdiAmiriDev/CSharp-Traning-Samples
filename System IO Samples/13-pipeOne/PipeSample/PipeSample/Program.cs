


using System.Diagnostics;

while (true)
{
    switch (Console.ReadLine().ToLower())
    {
        case "server":
            Server();
            break;
        case "client":
            Client();
            break;
        default:
            break;
    }
}



static void Server()
{
    Process pipe = new Process();
    pipe.StartInfo.FileName = 
}

static void Client()
{

}