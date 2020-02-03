using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class UserTests
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
        [Ignore("Skip")]
        public async Task BlockUser()
        {
            try
            {
                await TwitchService.BlockUserAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task CheckUserFollowsByChannel()
        {
            var results = await TwitchService.CheckUserFollowsByChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task CheckUserSubscriptionByChannel()
        {
            var results = await TwitchService.CheckUserSubscriptionByChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task FollowChannel()
        {
            var results = await TwitchService.FollowChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUser()
        {
            var results = await TwitchService.GetUserAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserBlockList()
        {
            var results = await TwitchService.GetUserBlockListAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserByID()
        {
            var results = await TwitchService.GetUserByIDAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserByName()
        {
            var results = await TwitchService.GetUserByNameAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserEmotes()
        {
            var results = await TwitchService.GetUserEmotesAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserFollows()
        {
            var results = await TwitchService.GetUserFollowsAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task GetUsersByName()
        {
            var results = await TwitchService.GetUsersByNameAsync(service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task UnblockUser()
        {
            try
            {
                await TwitchService.UnblockUserAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        [Ignore("Skip")]
        public async Task UnfollowChannel()
        {
            try
            {
                await TwitchService.UnfollowChannelAsync(service, channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task UserFollowsChannel()
        {
            var results = await TwitchService.UserFollowsChannelAsync(service, channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }
    }
}