using VkMusicToStream.Core.Models;

namespace VkMusicToStream.Core
{
    public class AudioStatus
    {
        public static async Task Get()
        {
            try
            {
                Thread thread = new Thread(Start);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception e)
            {
                Program.ClearConsole();
                Console.WriteLine($"> Get Audio Status Exception: {e.Message}");
            }
        }

        private static async void Start()
        {            
            while (true)
            {
                await Logic();

                Thread.Sleep(1000);
            }
        }

        private static async Task Logic()
        {
            if (!VkData.vkApi.IsAuthorized) return;

            var profileId = VkData.vkApi.UserId;
            var status = await VkData.vkApi.Status.GetAsync((long)profileId);
            if (status.Audio == null)
            {
                Program.ClearConsole();
                Console.WriteLine($"> Audio status is null!");
                VkData.NowPlayed = null;

                if (File.Exists(@"audio.txt"))
                    File.WriteAllText(@"audio.txt", string.Empty);

                return;
            }
            //
            if (VkData.NowPlayed == $"{status.Audio.Artist} - {status.Audio.Title}") return;
            //
            VkData.NowPlayed = $"{status.Audio.Artist} - {status.Audio.Title}";
            Program.ClearConsole();
            Console.WriteLine($"Now played: {status.Audio.Artist} - {status.Audio.Title}");
            File.WriteAllText(@"audio.txt", $"{status.Audio.Artist} - {status.Audio.Title}    ");
        }
    }
}
