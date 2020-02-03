using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class ChatTests
    {
        private User channel;
        private TwitchAPI service;

        [SetUp]
        public void Setup()
        {
            TokenService.LoadTokenList();
            service = new TwitchAPI();
            service.Settings.ClientId = TokenService.Tokens.ClientID;
            service.Settings.AccessToken = TokenService.Tokens.AccessToken;
            service.Settings.Secret = TokenService.Tokens.ClientSecret;
            channel = TwitchService.GetUserByNameAsync(service).Result.Matches[0];
        }

        [Test]
        public async Task GetAllChatEmoticons()
        {
            var results = await TwitchService.GetAllChatEmoticonsAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Emoticons);
        }

        [Test]
        public async Task GetChatBadgesByChannel()
        {
            var results = await TwitchService.GetChatBadgesByChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChatRoomsByChannel()
        {
            var results = await TwitchService.GetChatRoomsByChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Rooms);
        }
    }
}