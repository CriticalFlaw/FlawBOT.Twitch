using FlawBOT.Service;
using NUnit.Framework;

namespace Tests
{
    public class TwitchTests
    {
        private readonly string ChannelID = TokenService.Tokens.Channel;
        private readonly string UserID = TokenService.Tokens.Username;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetUserSubscription()
        {
            Assert.NotNull(Program.GetUserSubscription(ChannelID, UserID).Result);
        }

        [Test]
        public void GetUserFollows()
        {
            Assert.NotNull(Program.GetUserFollows(UserID).Result);
        }

        [Test]
        public void GetChannelSubscribers()
        {
            Assert.NotNull(Program.GetChannelSubscribers(ChannelID).Result);
        }

        [Test]
        public void GetChannelFollowers()
        {
            Assert.NotNull(Program.GetChannelFollowers(ChannelID).Result);
        }

        [Test]
        public void IsChannelOnline()
        {
            Assert.NotNull(Program.IsChannelOnline(ChannelID).Result);
        }

        [Test]
        public void SetStreamTitle()
        {
            Assert.NotNull(Program.SetStreamTitle(ChannelID, "Testing FlawBOT").Result);
        }

        [Test]
        public void SetStreamGame()
        {
            Assert.IsTrue(Program.SetStreamGame(ChannelID, "Team Fortress 2").Result);
        }
    }
}