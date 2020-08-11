using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FlawBOT.Core.Services
{
    public static class TokenHandler
    {
        public static TokenData Tokens { get; set; } = new TokenData();

        public static void LoadTokenList()
        {
            var json = new StreamReader(File.OpenRead("config.json"), new UTF8Encoding(false)).ReadToEnd();
            Tokens = JsonConvert.DeserializeObject<TokenData>(json);
        }
    }

    public class TokenData
    {
        [JsonProperty("bot_username")]
        public string BotUsername { get; set; }

        [JsonProperty("bot_oauth")]
        public string OAuth { get; set; }

        [JsonProperty("bot_access")]
        public string AccessToken { get; set; }

        [JsonProperty("bot_refresh")]
        public string RefreshToken { get; set; }

        [JsonProperty("twitch_channel")]
        public string ChannelName { get; set; }

        [JsonProperty("twitch_client")]
        public string ClientId { get; set; }

        [JsonProperty("twitch_secret")]
        public string ClientSecret { get; set; }
    }
}