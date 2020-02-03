using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class SearchTests
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
        public async Task SearchChannels()
        {
            var results = await TwitchService.SearchChannelsAsync(service, "criticalflaw_").ConfigureAwait(false);
            Assert.IsNotNull(results.Channels);
        }

        [Test]
        public async Task SearchGames()
        {
            var results = await TwitchService.SearchGamesAsync(service, "Team Fortress 2").ConfigureAwait(false);
            Assert.IsNotNull(results.Games);
        }

        [Test]
        public async Task SearchStreams()
        {
            var results = await TwitchService.SearchStreamsAsync(service, "criticalflaw_").ConfigureAwait(false);
            Assert.IsNotNull(results.Streams);
        }
    }
}