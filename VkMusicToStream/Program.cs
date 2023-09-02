using System.Text;
using VkMusicToStream.Core;
using VkMusicToStream.Core.Models;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        ClearConsole();
        Console.WriteLine("> Login:");
        VkData.Login = Console.ReadLine();
        Console.WriteLine($"> Password:");
        VkData.Password = Console.ReadLine();
        ClearConsole();
        Console.WriteLine("> Try auth...");
        await VkAutorization.TryAuth(VkData.Login, VkData.Password);


        Console.ReadLine();
    }

    public static void ClearConsole()
    {
        Console.Clear();
        Console.WriteLine($"Developer: twitch.tv/danekwild\n");
    }
}