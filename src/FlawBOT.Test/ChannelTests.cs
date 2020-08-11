using System.Threading.Tasks;
using FlawBOT.Service;
using NUnit.Framework;

namespace FlawBOT.Test
{
    public class ChannelTests
    {
        [Test]
        public async Task CheckChannelSubscriptionByUser()
        {
            var results = await APIService.CheckChannelSubscriptionByUserAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task DeleteChannelFromCommunity()
        {
            try
            {
                await APIService.DeleteChannelFromCommunityAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
            var results = await APIService.GetAllFollowersAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetAllSubscribers()
        {
            var results = await APIService.GetAllSubscribersAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannel()
        {
            var results = await APIService.GetChannelAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelById()
        {
            var results = await APIService.GetChannelByIDAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelCommunities()
        {
            var results = await APIService.GetChannelCommunitiesAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results.Communities);
        }

        [Test]
        public async Task GetChannelCommunity()
        {
            var results = await APIService.GetChannelCommunityAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelEditors()
        {
            var results = await APIService.GetChannelEditorsAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Editors);
        }

        [Test]
        public async Task GetChannelFollowers()
        {
            var results = await APIService.GetChannelFollowersAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelSubscribers()
        {
            var results = await APIService.GetChannelSubscribersAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChannelTeams()
        {
            var results = await APIService.GetChannelTeamsAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Teams);
        }

        [Test]
        public async Task GetChannelVideos()
        {
            var results = await APIService.GetChannelVideosAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task ResetChannelStreamKey()
        {
            try
            {
                await APIService.ResetChannelStreamKeyAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
                await APIService.SetChannelCommunitiesAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
                await APIService.StartChannelCommercialAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
                await APIService.UpdateChannelAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
                Assert.Pass();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}