﻿using VkNet;

namespace VkMusicToStream.Core.Models
{
    public class VkData
    {
        public static VkApi vkApi = new VkApi();
        public static ulong appId = 0000001;
        public static string? Login = null;
        public static string? Password = null;
        public static string? NowPlayed = null;
    }
}
