using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class SearchTests
    {
        [Test]
        public async Task SearchChannels()
        {
            var results = await APIService.SearchChannelsAsync(Setup.Service, "criticalflaw_").ConfigureAwait(false);
            Assert.IsNotNull(results.Channels);
        }

        [Test]
        public async Task SearchGames()
        {
            var results = await APIService.SearchGamesAsync(Setup.Service, "Team Fortress 2").ConfigureAwait(false);
            Assert.IsNotNull(results.Games);
        }

        [Test]
        public async Task SearchStreams()
        {
            var results = await APIService.SearchStreamsAsync(Setup.Service, "criticalflaw_").ConfigureAwait(false);
            Assert.IsNotNull(results.Streams);
        }
    }
}