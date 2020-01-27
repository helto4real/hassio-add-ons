using System.Threading.Tasks;
using JoySoftware.HomeAssistant.NetDaemon.Common;
public class HelloWorldApp : NetDaemonApp
{
    public async override Task InitializeAsync()
    {
        Log("Hello World!");

    }
}