using System.Text;
using VkMusicToStream.Core;
using VkMusicToStream.Core.Models;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine($"Developer: twitch.tv/danekwild\n");
        Console.WriteLine("> Login:");
        VkData.Login = Console.ReadLine();
        Console.WriteLine($"> Password:");
        VkData.Password = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("> Try auth...");
        await VkAutorization.TryAuth(VkData.Login, VkData.Password);


        Console.ReadLine();
    }
}