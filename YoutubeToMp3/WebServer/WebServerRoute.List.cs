using System.Net;
using Newtonsoft.Json;
using YDLib;

namespace YoutubeToMp3.WebServer;

internal partial class WebServerRoute
{
    public (HttpListenerResponse response, string data) GetList(HttpListenerContext context)
    {
        var files = Directory.GetFiles(GlobalFunction.GetDownloadPath());

        List<FileItem> listFileInfo = new();
        foreach (string fileUri in files)
        {
            listFileInfo.Add(new FileItem(fileUri));
        }

        string logResult = JsonConvert.SerializeObject(listFileInfo);
        
        Console.WriteLine(logResult);
        
        HttpListenerResponse response = context.Response;
        
        (HttpListenerResponse response, string data) result = (response, logResult);
        return result;
    }
}