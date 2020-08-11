using System.Threading.Tasks;
using FlawBOT.Service;
using NUnit.Framework;

namespace FlawBOT.Test
{
    public class UserTests
    {
        [Test]
        [Ignore("Skip")]
        public async Task BlockUser()
        {
            try
            {
                await APIService.BlockUserAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
            var results = await APIService.CheckUserFollowsByChannelAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task CheckUserSubscriptionByChannel()
        {
            var results = await APIService.CheckUserSubscriptionByChannelAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task FollowChannel()
        {
            var results = await APIService.FollowChannelAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUser()
        {
            var results = await APIService.GetUserAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserBlockList()
        {
            var results = await APIService.GetUserBlockListAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserByID()
        {
            var results = await APIService.GetUserByIDAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserByName()
        {
            var results = await APIService.GetUserByNameAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserEmotes()
        {
            var results = await APIService.GetUserEmotesAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetUserFollows()
        {
            var results = await APIService.GetUserFollowsAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task GetUsersByName()
        {
            var results = await APIService.GetUsersByNameAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        [Ignore("Skip")]
        public async Task UnblockUser()
        {
            try
            {
                await APIService.UnblockUserAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
                await APIService.UnfollowChannelAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
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
            var results = await APIService.UserFollowsChannelAsync(Setup.Service, Setup.Channel)
                .ConfigureAwait(false);
            Assert.IsNotNull(results);
        }
    }
}