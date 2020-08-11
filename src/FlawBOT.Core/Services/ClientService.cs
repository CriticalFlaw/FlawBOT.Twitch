using System;
using System.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Extensions;

namespace FlawBOT.Service
{
    internal static class ClientService
    {
        #region BOT

        internal static void Reconnect(TwitchClient client)
        {
            client.Reconnect();
        }

        internal static void Disconnect(TwitchClient client)
        {
            client.SendMessage(client.JoinedChannels.First(), "Goodbye!");
            client.Disconnect();
        }

        internal static void SendWhisper(TwitchClient client, string user, string message)
        {
            client.SendWhisper(user, message);
        }

        internal static void ReplyToWhisper(TwitchClient client, string message)
        {
            client.ReplyToLastWhisper(message);
        }

        #endregion BOT

        #region CHANNEL_CHAT

        internal static void SendMessage(TwitchClient client, string message)
        {
            client.SendMessage(client.GetJoinedChannel(client.JoinedChannels[0].Channel), message);
        }

        internal static void ClearChat(TwitchClient client)
        {
            client.ClearChat(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel);
        }

        #endregion CHANNEL_CHAT

        #region CHANNEL_STATE

        internal static void EmoteOnlyOff(TwitchClient client)
        {
            client.EmoteOnlyOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void EmoteOnlyOn(TwitchClient client)
        {
            client.EmoteOnlyOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void FollowersOnlyOff(TwitchClient client)
        {
            client.FollowersOnlyOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void FollowersOnlyOn(TwitchClient client, TimeSpan minutes)
        {
            client.FollowersOnlyOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel), minutes);
        }

        internal static void SlowModeOff(TwitchClient client)
        {
            client.SlowModeOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void SlowModeOn(TwitchClient client, TimeSpan minutes)
        {
            client.SlowModeOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel), minutes);
        }

        internal static void SubscribersOnlyOff(TwitchClient client)
        {
            client.SubscribersOnlyOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void SubscribersOnlyOn(TwitchClient client)
        {
            client.SubscribersOnlyOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void StartCommercial(TwitchClient client, CommercialLength minutes)
        {
            client.StartCommercial(client.GetJoinedChannel(client.JoinedChannels[0].Channel), minutes);
        }

        #endregion CHANNEL_STATE

        #region CHANNEL_HOST

        internal static void Host(TwitchClient client, string channel)
        {
            client.Host(client.GetJoinedChannel(client.JoinedChannels[0].Channel), channel);
        }

        internal static void Unhost(TwitchClient client)
        {
            client.Unhost(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void Raid(TwitchClient client, string channel)
        {
            client.Raid(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, channel);
        }

        #endregion CHANNEL_HOST

        #region USER_BAN

        internal static void BanUser(TwitchClient client, string user)
        {
            client.BanUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, user);
        }

        internal static void UnbanUser(TwitchClient client, string user)
        {
            client.UnbanUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user);
        }

        internal static void TimeoutUser(TwitchClient client, string user, TimeSpan minutes, string reason)
        {
            client.TimeoutUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user, minutes, reason);
        }

        #endregion USER_BAN

        #region USER_MOD

        internal static void Mod(TwitchClient client, string user)
        {
            client.Mod(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, user);
        }

        internal static void Unmod(TwitchClient client, string user)
        {
            client.Unmod(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user);
        }

        #endregion USER_MOD
    }
}