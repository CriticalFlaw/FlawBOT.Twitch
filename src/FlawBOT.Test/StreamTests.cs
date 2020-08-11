using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class StreamTests
    {
        [Test]
        public async Task BroadcasterOnline()
        {
            var results = await APIService.BroadcasterOnlineAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetFeaturedStream()
        {
            var results = await APIService.GetFeaturedStreamAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results.Featured);
        }

        [Test]
        public async Task GetFollowedStreams()
        {
            var results = await APIService.GetFollowedStreamsAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Streams);
        }

        [Test]
        [Ignore("Skip")]
        public async Task GetLiveStreams()
        {
            var results = await APIService.GetLiveStreamsAsync(Setup.Service).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetStreamByUser()
        {
            var results = await APIService.GetStreamByUserAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Stream);
        }

        [Test]
        public async Task GetStreamsSummary()
        {
            var results = await APIService.GetStreamsSummaryAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Channels);
        }

        [Test]
        public async Task GetUptime()
        {
            var results = await APIService.GetUptimeAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }
    }
}