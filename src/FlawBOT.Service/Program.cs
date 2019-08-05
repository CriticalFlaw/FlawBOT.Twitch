using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Users;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Api.V5.Models.Subscriptions;

namespace FlawBOT.Service
{
    public class Program
    {
        private static TwitchAPI api;

        private void Main()
        {
            api = new TwitchAPI();
            api.Settings.ClientId = TokenService.Tokens.ClientID;
            api.Settings.AccessToken = TokenService.Tokens.OAuth;
        }

        /// <summary>
        /// Checks subscription for a specific user and the channel specified
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <param name="user">User ID</param>
        /// <returns>User Subscriptions</returns>
        public static async Task<Subscription> GetUserSubscription(string channel, string user)
        {
            var results = await api.V5.Channels.CheckChannelSubscriptionByUserAsync(channel, user);
            return results;
        }

        /// <summary>
        /// Get channels a specified user follows
        /// </summary>
        /// <param name="user">User ID</param>
        /// <returns>User Follows</returns>
        public static async Task<GetUsersFollowsResponse> GetUserFollows(string user)
        {
            var results = await api.Helix.Users.GetUsersFollowsAsync(user);
            return results;
        }

        /// <summary>
        /// Gets a list of all the subscritions of the specified channel
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <returns>List of Subscriptions</returns>
        public static async Task<List<Subscription>> GetChannelSubscribers(string channel)
        {
            var results = await api.V5.Channels.GetAllSubscribersAsync(channel);
            return results;
        }

        /// <summary>
        /// Get Spedicified Channel Follows
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <returns>Channel followers</returns>
        public static async Task<ChannelFollowers> GetChannelFollowers(string channel)
        {
            var results = await api.V5.Channels.GetChannelFollowersAsync(channel);
            return results;
        }

        /// <summary>
        /// Return bool if channel is online/offline
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <returns>TRUE if channel is online, otherwise FALSE</returns>
        public static async Task<bool> IsChannelOnline(string channel)
        {
            var results = await api.V5.Streams.BroadcasterOnlineAsync(channel);
            return results;
        }

        /// <summary>
        /// Update Stream Title
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <param name="title">Stream Title</param>
        /// <returns>Confirmation Boolean</returns>
        public static async Task<bool> SetStreamTitle(string channel, string title)
        {
            await api.V5.Channels.UpdateChannelAsync(channel, status: title);
            return true;
        }

        /// <summary>
        /// Update Stream Game
        /// </summary>
        /// <param name="channel">Channel ID</param>
        /// <param name="game">Stream Game</param>
        /// <returns>Confirmation Boolean</returns>
        public static async Task<bool> SetStreamGame(string channel, string game)
        {
            await api.V5.Channels.UpdateChannelAsync(channel, game: game);
            return true;
        }
    }
}