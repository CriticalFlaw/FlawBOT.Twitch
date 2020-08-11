using FlawBOT.Service;
using NUnit.Framework;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Test
{
    public class ChatTests
    {
        [Test]
        public async Task GetAllChatEmoticons()
        {
            var results = await APIService.GetAllChatEmoticonsAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Emoticons);
        }

        [Test]
        public async Task GetChatBadgesByChannel()
        {
            var results = await APIService.GetChatBadgesByChannelAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GetChatRoomsByChannel()
        {
            var results = await APIService.GetChatRoomsByChannelAsync(Setup.Service, Setup.Channel).ConfigureAwait(false);
            Assert.IsNotNull(results.Rooms);
        }
    }
}