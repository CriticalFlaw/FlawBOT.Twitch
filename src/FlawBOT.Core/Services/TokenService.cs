using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace FlawBOT.Service
{
    public static class TokenService
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
        [JsonProperty("twitch_client")]
        public string ClientID { get; set; }

        [JsonProperty("twitch_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("twitch_channel")]
        public string ChannelName { get; set; }

        [JsonProperty("bot_username")]
        public string BotUsername { get; set; }

        [JsonProperty("bot_access")]
        public string AccessToken { get; set; }

        [JsonProperty("bot_refresh")]
        public string RefreshToken { get; set; }

        [JsonProperty("bot_oauth")]
        public string OAuth { get; set; }
    }
}