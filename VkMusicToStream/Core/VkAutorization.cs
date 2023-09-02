using VkMusicToStream.Core.Models;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkMusicToStream.Core
{
    public class VkAutorization
    {
        public static async Task TryAuth(string login, string password)
        {
            try
            {
                await VkData.vkApi.AuthorizeAsync(new ApiAuthParams
                {
                    ApplicationId = VkData.appId,
                    Login = login,
                    Password = password,
                    Settings = Settings.All,
                    TwoFactorAuthorization = () =>
                    {
                        Program.ClearConsole();
                        Console.WriteLine("> Enter 2FA Code:");
                        return Console.ReadLine();
                    }                    
                });

                Program.ClearConsole();
                var result = await VkData.vkApi.Account.GetProfileInfoAsync();
                Console.WriteLine($"> Hello, {result.FirstName} {result.LastName}!\n");
                await AudioStatus.Get();
            }
            catch (Exception e)
            {
                Program.ClearConsole();
                Console.WriteLine($"Auth Exception: {e.Message}");
            }
        }
    }
}
