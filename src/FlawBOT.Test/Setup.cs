using System.IO;
using System.Text;
using FlawBOT.Core.Services;
using FlawBOT.Service;
using Newtonsoft.Json;
using NUnit.Framework;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    [SetUpFixture]
    internal class Setup
    {
        public static User Channel;
        public static TwitchAPI Service;

        [OneTimeSetUp]
        public void PreTest()
        {
            var json = new StreamReader(File.OpenRead("config.json"), new UTF8Encoding(false)).ReadToEnd();
            TokenHandler.Tokens = JsonConvert.DeserializeObject<TokenData>(json);
            TokenHandler.LoadTokenList();
            Service = new TwitchAPI();
            //service.Settings.ClientId = TokenHandler.Tokens.ClientID;
            Service.Settings.AccessToken = TokenHandler.Tokens.AccessToken;
            Service.Settings.Secret = TokenHandler.Tokens.ClientSecret;
            Channel = APIService.GetUserByNameAsync(Service).Result.Matches[0];
        }
    }
}