using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class ChannelTests
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
        public async Task CheckChannelSubscriptionByUser()
        {
            var results = await TwitchService.CheckChannelSubscriptionByUserAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task DeleteChannelFromCommunity()
        {
            try
            {
                await TwitchService.DeleteChannelFromCommunityAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task GetAllFollowers()
        {
            var results = await TwitchService.GetAllFollowersAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetAllSubscribers()
        {
            var results = await TwitchService.GetAllSubscribersAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannel()
        {
            var results = await TwitchService.GetChannelAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelByID()
        {
            var results = await TwitchService.GetChannelByIDAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelCommunities()
        {
            var results = await TwitchService.GetChannelCommunitiesAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Communities);
        }

        [Test]
        public async Task GetChannelCommunity()
        {
            var results = await TwitchService.GetChannelCommunityAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelEditors()
        {
            var results = await TwitchService.GetChannelEditorsAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Editors);
        }

        [Test]
        public async Task GetChannelFollowers()
        {
            var results = await TwitchService.GetChannelFollowersAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelSubscribers()
        {
            var results = await TwitchService.GetChannelSubscribersAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelTeams()
        {
            var results = await TwitchService.GetChannelTeamsAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Teams);
        }

        [Test]
        public async Task GetChannelVideos()
        {
            var results = await TwitchService.GetChannelVideosAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task ResetChannelStreamKey()
        {
            try
            {
                await TwitchService.ResetChannelStreamKeyAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        [Ignore("Skip")]
        public async Task SetChannelCommunities()
        {
            try
            {
                await TwitchService.SetChannelCommunitiesAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task StartChannelCommercial()
        {
            try
            {
                await TwitchService.StartChannelCommercialAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task UpdateChannel()
        {
            try
            {
                await TwitchService.UpdateChannelAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}