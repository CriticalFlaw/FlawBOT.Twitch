using System;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Extensions;

namespace FlawBOT.Service
{
    internal static class BotService
    {
        internal static void BanUser(TwitchClient client, string user)
        {
            client.BanUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, user);
        }

        internal static void ClearChat(TwitchClient client)
        {
            client.ClearChat(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel);
        }

        internal static void ChangeChatColor(TwitchClient client, ChatColorPresets color)
        {
            client.ChangeChatColor(client.GetJoinedChannel(client.JoinedChannels[0].Channel), color);
        }

        internal static void Disconnect(TwitchClient client)
        {
            client.Disconnect();
        }

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

        internal static void Host(TwitchClient client, string channel)
        {
            client.Host(client.GetJoinedChannel(client.JoinedChannels[0].Channel), channel);
        }

        internal static void JoinChannel(TwitchClient client)
        {
            client.JoinChannel(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel);
        }

        internal static void JoinRoom(TwitchClient client, string roomId)
        {
            client.JoinRoom(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, roomId);
        }

        internal static void LeaveChannel(TwitchClient client)
        {
            client.LeaveChannel(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel);
        }

        internal static void LeaveRoom(TwitchClient client, string roomId)
        {
            client.LeaveRoom(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, roomId);
        }

        internal static void Mod(TwitchClient client, string user)
        {
            client.Mod(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, user);
        }

        internal static void Raid(TwitchClient client, string channel)
        {
            client.Raid(client.GetJoinedChannel(client.JoinedChannels[0].Channel).Channel, channel);
        }

        internal static void Reconnect(TwitchClient client)
        {
            client.Reconnect();
        }

        internal static void ReplyToLastWhisper(TwitchClient client, string message)
        {
            client.ReplyToLastWhisper(message);
        }

        internal static void SendMessage(TwitchClient client, string message)
        {
            client.SendMessage(client.GetJoinedChannel(client.JoinedChannels[0].Channel), message);
        }

        internal static void SendQueuedItem(TwitchClient client, string message)
        {
            client.SendQueuedItem(message);
        }

        internal static void SendRaw(TwitchClient client, string message)
        {
            client.SendRaw(message);
        }

        internal static void SendWhisper(TwitchClient client, string user, string message)
        {
            client.SendWhisper(user, message);
        }

        internal static void SlowModeOff(TwitchClient client)
        {
            client.SlowModeOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void SlowModeOn(TwitchClient client, TimeSpan minutes)
        {
            client.SlowModeOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel), minutes);
        }

        internal static void StartCommercial(TwitchClient client, CommercialLength minutes)
        {
            client.StartCommercial(client.GetJoinedChannel(client.JoinedChannels[0].Channel), minutes);
        }

        internal static void SubscribersOnlyOff(TwitchClient client)
        {
            client.SubscribersOnlyOff(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void SubscribersOnlyOn(TwitchClient client)
        {
            client.SubscribersOnlyOn(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void TimeoutUser(TwitchClient client, string user, TimeSpan minutes, string reason)
        {
            client.TimeoutUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user, minutes, reason);
        }

        internal static void UnbanUser(TwitchClient client, string user)
        {
            client.UnbanUser(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user);
        }

        internal static void Unhost(TwitchClient client)
        {
            client.Unhost(client.GetJoinedChannel(client.JoinedChannels[0].Channel));
        }

        internal static void Unmod(TwitchClient client, string user)
        {
            client.Unmod(client.GetJoinedChannel(client.JoinedChannels[0].Channel), user);
        }
    }
}