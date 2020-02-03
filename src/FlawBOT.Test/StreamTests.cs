using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class StreamTests
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
        public async Task BroadcasterOnline()
        {
            var results = await TwitchService.BroadcasterOnlineAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetFeaturedStream()
        {
            var results = await TwitchService.GetFeaturedStreamAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results.Featured);
        }

        [Test]
        public async Task GetFollowedStreams()
        {
            var results = await TwitchService.GetFollowedStreamsAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Streams);
        }

        [Test]
        [Ignore("Skip")]
        public async Task GetLiveStreams()
        {
            var results = await TwitchService.GetLiveStreamsAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetStreamByUser()
        {
            var results = await TwitchService.GetStreamByUserAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Stream);
        }

        [Test]
        public async Task GetStreamsSummary()
        {
            var results = await TwitchService.GetStreamsSummaryAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Channels);
        }

        [Test]
        public async Task GetUptime()
        {
            var results = await TwitchService.GetUptimeAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }
    }
}