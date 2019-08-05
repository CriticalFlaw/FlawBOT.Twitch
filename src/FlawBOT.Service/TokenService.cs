using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace FlawBOT.Service
{
    public class TokenService
    {
        public static TokenData Tokens { get; set; } = new TokenData();

        public static void UpdateTokenList()
        {
            var json = new StreamReader(File.OpenRead("config.json"), new UTF8Encoding(false)).ReadToEnd();
            Tokens = JsonConvert.DeserializeObject<TokenData>(json);
        }
    }

    public class TokenData
    {
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("twitch_client")]
        public string ClientID { get; private set; }

        [JsonProperty("twitch_username")]
        public string Username { get; private set; }

        [JsonProperty("twitch_oauth")]
        public string OAuth { get; private set; }

        [JsonProperty("twitch_channel")]
        public string Channel { get; private set; }
    }
}