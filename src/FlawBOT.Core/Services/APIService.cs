using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlawBOT.Core.Services;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Api.V5.Models.Chat;
using TwitchLib.Api.V5.Models.Communities;
using TwitchLib.Api.V5.Models.Search;
using TwitchLib.Api.V5.Models.Streams;
using TwitchLib.Api.V5.Models.Subscriptions;
using TwitchLib.Api.V5.Models.Users;

namespace FlawBOT.Service
{
    public static class APIService
    {
        #region CHANNEL

        public static async Task<Subscription> CheckChannelSubscriptionByUserAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.CheckChannelSubscriptionByUserAsync(channel.Id, channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<bool> DeleteChannelFromCommunityAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Channels.DeleteChannelFromCommunityAsync(channel.Id).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<List<ChannelFollow>> GetAllFollowersAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetAllFollowersAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<List<Subscription>> GetAllSubscribersAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetAllSubscribersAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelAuthed> GetChannelAsync(TwitchAPI service)
        {
            var results = await service.V5.Channels.GetChannelAsync().ConfigureAwait(false);
            return results;
        }

        public static async Task<Channel> GetChannelByIDAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelByIDAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<CommunitiesResponse> GetChannelCommunitiesAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelCommunitiesAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<Community> GetChannelCommunityAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelCommunityAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelEditors> GetChannelEditorsAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelEditorsAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelFollowers> GetChannelFollowersAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelFollowersAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelSubscribers> GetChannelSubscribersAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelSubscribersAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelTeams> GetChannelTeamsAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelTeamsAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelVideos> GetChannelVideosAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Channels.GetChannelVideosAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<bool> ResetChannelStreamKeyAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Channels.ResetChannelStreamKeyAsync(channel.Id).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SetChannelCommunitiesAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Channels.SetChannelCommunitiesAsync(channel.Id, null).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> StartChannelCommercialAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Channels.StartChannelCommercialAsync(channel.Id, TwitchLib.Api.Core.Enums.CommercialLength.Seconds30).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> UpdateChannelAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Channels.UpdateChannelAsync(channel.Id, "Testing FlawBOT", "Programming").ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion CHANNEL

        #region CHAT

        public static async Task<AllChatEmotes> GetAllChatEmoticonsAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Chat.GetAllChatEmoticonsAsync().ConfigureAwait(false);
            return results;
        }

        public static async Task<ChannelBadges> GetChatBadgesByChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Chat.GetChatBadgesByChannelAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<ChatRoomsByChannelResponse> GetChatRoomsByChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Chat.GetChatRoomsByChannelAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        #endregion CHAT

        #region SEARCH

        public static async Task<SearchChannels> SearchChannelsAsync(TwitchAPI service, string channel)
        {
            var results = await service.V5.Search.SearchChannelsAsync(channel).ConfigureAwait(false);
            return results;
        }

        public static async Task<SearchGames> SearchGamesAsync(TwitchAPI service, string game)
        {
            var results = await service.V5.Search.SearchGamesAsync(game).ConfigureAwait(false);
            return results;
        }

        public static async Task<SearchStreams> SearchStreamsAsync(TwitchAPI service, string stream)
        {
            var results = await service.V5.Search.SearchStreamsAsync(stream).ConfigureAwait(false);
            return results;
        }

        #endregion SEARCH

        #region STREAM

        public static async Task<bool> BroadcasterOnlineAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Streams.BroadcasterOnlineAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<FeaturedStreams> GetFeaturedStreamAsync(TwitchAPI service)
        {
            var results = await service.V5.Streams.GetFeaturedStreamAsync(1).ConfigureAwait(false);
            return results;
        }

        public static async Task<FollowedStreams> GetFollowedStreamsAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Streams.GetFollowedStreamsAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<LiveStreams> GetLiveStreamsAsync(TwitchAPI service)
        {
            var results = await service.V5.Streams.GetLiveStreamsAsync(null).ConfigureAwait(false);
            return results;
        }

        public static async Task<StreamByUser> GetStreamByUserAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Streams.GetStreamByUserAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<StreamsSummary> GetStreamsSummaryAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Streams.GetStreamsSummaryAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<TimeSpan?> GetUptimeAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Streams.GetUptimeAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        #endregion STREAM

        #region USER

        public static async Task<bool> BlockUserAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Users.BlockUserAsync(channel.Id, null).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<UserFollow> CheckUserFollowsByChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.CheckUserFollowsByChannelAsync(channel.Id, channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<Subscription> CheckUserSubscriptionByChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.CheckUserSubscriptionByChannelAsync(channel.Id, channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<UserFollow> FollowChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.FollowChannelAsync(channel.Id, channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<UserAuthed> GetUserAsync(TwitchAPI service)
        {
            var results = await service.V5.Users.GetUserAsync().ConfigureAwait(false);
            return results;
        }

        public static async Task<UserBlocks> GetUserBlockListAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.GetUserBlockListAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<User> GetUserByIDAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.GetUserByIDAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<Users> GetUserByNameAsync(TwitchAPI service)
        {
            var results = await service.V5.Users.GetUserByNameAsync(TokenHandler.Tokens.ChannelName).ConfigureAwait(false);
            return results;
        }

        public static async Task<UserEmotes> GetUserEmotesAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.GetUserEmotesAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<UserFollows> GetUserFollowsAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.GetUserFollowsAsync(channel.Id).ConfigureAwait(false);
            return results;
        }

        public static async Task<Users> GetUsersByNameAsync(TwitchAPI service)
        {
            var results = await service.V5.Users.GetUsersByNameAsync(null).ConfigureAwait(false);
            return results;
        }

        public static async Task<bool> UnblockUserAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Users.UnblockUserAsync(channel.Id, channel.Id).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> UnfollowChannelAsync(TwitchAPI service, User channel)
        {
            try
            {
                await service.V5.Users.UnfollowChannelAsync(channel.Id, channel.Id).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> UserFollowsChannelAsync(TwitchAPI service, User channel)
        {
            var results = await service.V5.Users.UserFollowsChannelAsync(channel.Id, channel.Id).ConfigureAwait(false);
            return results;
        }

        #endregion USER
    }
}