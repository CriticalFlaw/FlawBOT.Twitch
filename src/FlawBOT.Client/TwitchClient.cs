using System;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace FlawBOT
{
    public class TwitchClient
    {
        private TwitchLib.Client.TwitchClient client;
        private TwitchAPI service;

        public TwitchClient()
        {
            TokenService.UpdateTokenList();
            client = new TwitchLib.Client.TwitchClient();
            client.Initialize((new ConnectionCredentials(TokenService.Tokens.Username, TokenService.Tokens.OAuth)), TokenService.Tokens.Channel);

            // Initialize the Twitch bot's event handlers.
            client.OnBeingHosted += Client_OnBeingHosted;
            client.OnChannelStateChanged += Client_OnChannelStateChanged;
            client.OnChatCleared += Client_OnChatCleared;
            client.OnChatColorChanged += Client_OnChatColorChanged;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.OnCommunitySubscription += Client_OnCommunitySubscription;
            client.OnConnected += Client_OnConnected;
            client.OnConnectionError += Client_OnConnectionError;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnError += Client_OnError;
            client.OnExistingUsersDetected += Client_OnExistingUsersDetected;
            client.OnFailureToReceiveJoinConfirmation += Client_OnFailureToReceiveJoinConfirmation;
            client.OnGiftedSubscription += Client_OnGiftedSubscription;
            client.OnHostingStarted += Client_OnHostingStarted;
            client.OnHostingStopped += Client_OnHostingStopped;
            client.OnHostLeft += Client_OnHostLeft;
            client.OnIncorrectLogin += Client_OnIncorrectLogin;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnLeftChannel += Client_OnLeftChannel;
            client.OnLog += Client_OnLog;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnMessageSent += Client_OnMessageSent;
            client.OnMessageThrottled += Client_OnMessageThrottled;
            client.OnModeratorJoined += Client_OnModeratorJoined;
            client.OnModeratorLeft += Client_OnModeratorLeft;
            client.OnModeratorsReceived += Client_OnModeratorsReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnNoPermissionError += Client_OnNoPermissionError;
            client.OnNowHosting += Client_OnNowHosting;
            client.OnRaidedChannelIsMatureAudience += Client_OnRaidedChannelIsMatureAudience;
            client.OnRaidNotification += Client_OnRaidNotification;
            client.OnReconnected += Client_OnReconnected;
            client.OnReSubscriber += Client_OnReSubscriber;
            client.OnRitualNewChatter += Client_OnRitualNewChatter;
            client.OnSelfRaidError += Client_OnSelfRaidError;
            client.OnSendReceiveData += Client_OnSendReceiveData;
            client.OnUnaccountedFor += Client_OnUnaccountedFor;
            client.OnUserBanned += Client_OnUserBanned;
            client.OnUserJoined += Client_OnUserJoined;
            client.OnUserLeft += Client_OnUserLeft;
            client.OnUserStateChanged += Client_OnUserStateChanged;
            client.OnUserTimedout += Client_OnUserTimedout;
            client.OnWhisperCommandReceived += Client_OnWhisperCommandReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnWhisperSent += Client_OnWhisperSent;
            client.OnWhisperThrottled += Client_OnWhisperThrottled;

            service = new TwitchAPI();
            service.Settings.ClientId = TokenService.Tokens.ClientID;
            service.Settings.AccessToken = TokenService.Tokens.OAuth;
            client.Connect();
        }

        /// <summary>
        /// Called when the bot has received a whisper from another user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
            Console.WriteLine($"Whisper received from {e.WhisperMessage.DisplayName} ({e.WhisperMessage.UserId}): {e.WhisperMessage.Message}");
        }

        /// <summary>
        /// Called when a viewer has become a new subscriber.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.Subscriber.DisplayName} has subscribed {(e.Subscriber.SubscriptionPlan == TwitchLib.Client.Enums.SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
            client.SendMessage(e.Channel, $"{e.Subscriber.DisplayName} has subscribed {(e.Subscriber.SubscriptionPlan == TwitchLib.Client.Enums.SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
        }

        /// <summary>
        /// Called when the channel is being hosted by another channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnBeingHosted(object sender, OnBeingHostedArgs e)
        {
            Console.WriteLine($"Channel hosted by {e.BeingHostedNotification.HostedByChannel}.");
            client.SendMessage(e.BeingHostedNotification.Channel, $"Thank you {e.BeingHostedNotification.HostedByChannel} for hosting {e.BeingHostedNotification.Channel}!");
        }

        private void Client_OnChannelStateChanged(object sender, OnChannelStateChangedArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Channel State Changed.");
        }

        private void Client_OnChatCleared(object sender, OnChatClearedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Chat Cleared.");
        }

        private void Client_OnChatColorChanged(object sender, OnChatColorChangedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Chat Color Updated.");
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            Console.WriteLine($"Received Command: {e.Command.ChatMessage}");
            switch (e.Command.CommandText)
            {
                case "ban":
                    break;
            }
        }

        private void Client_OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Community Subscription.");
        }

        /// <summary>
        /// Called when the bot has successfully connected to a channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
            client.SendMessage(e.AutoJoinChannel, $"{e.BotUsername} has connected to {e.AutoJoinChannel}");
        }

        /// <summary>
        /// Called when the bot was unable to connect to the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"[ERROR] Connection Error: {e.Error.Message}");
        }

        private void Client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Disconnected.");
        }

        /// <summary>
        /// Called when an exception error has occurred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            Console.WriteLine($"[ERROR] {e.Exception.Message}");
        }

        private void Client_OnExistingUsersDetected(object sender, OnExistingUsersDetectedArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Existing Users Detected.");
        }

        private void Client_OnFailureToReceiveJoinConfirmation(object sender, OnFailureToReceiveJoinConfirmationArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Failure To Receive Join Confirmation.");
        }

        /// <summary>
        /// Called when someone got gifted a subscription to the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            Console.WriteLine($"{e.GiftedSubscription.DisplayName} has gifted a subscription to {e.GiftedSubscription.MsgParamRecipientDisplayName}.");
            client.SendMessage(e.Channel, $"{e.GiftedSubscription.DisplayName} has gifted a subscription to {e.GiftedSubscription.MsgParamRecipientDisplayName}.");
        }

        /// <summary>
        /// Called when the channel has started hosting another channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnHostingStarted(object sender, OnHostingStartedArgs e)
        {
            Console.WriteLine($"Started hosting {e.HostingStarted.TargetChannel} with {e.HostingStarted.Viewers} viewers.");
        }

        /// <summary>
        /// Called when the channel has stopped hosting another channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnHostingStopped(object sender, OnHostingStoppedArgs e)
        {
            Console.WriteLine($"Stopped hosting {e.HostingStopped.HostingChannel}.");
        }

        private void Client_OnHostLeft(object sender, EventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Host Left.");
        }

        private void Client_OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Incorrect Login.");
        }

        /// <summary>
        /// Called when the bot has successfully joined a channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.BotUsername} has joined the channel.");
            client.SendMessage(e.Channel, $"{e.BotUsername} has joined the channel.");
        }

        private void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.BotUsername} has left the channel.");
            client.SendMessage(e.Channel, $"{e.BotUsername} is leaving the channel.");
        }

        /// <summary>
        /// Called when an event has occurred that could be logged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: {e.Data}");
        }

        /// <summary>
        /// Called when a chat message has been received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            ChannelFollowers result;
            if (e.ChatMessage.Message.StartsWith("hello", StringComparison.InvariantCultureIgnoreCase))
                client.SendMessage(e.ChatMessage.Channel, $"Hello {e.ChatMessage.Username}. Welcome to the channel!");
            else if (e.ChatMessage.Message.StartsWith("followers") && e.ChatMessage.IsBroadcaster)
                result = TwitchService.GetChannelFollowers(service, e.ChatMessage.Channel).Result;
            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void Client_OnMessageSent(object sender, OnMessageSentArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Message Sent.");
        }

        private void Client_OnMessageThrottled(object sender, OnMessageThrottledEventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Message Throttled.");
        }

        /// <summary>
        /// Called when a moderator has joined the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnModeratorJoined(object sender, OnModeratorJoinedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Moderator {e.Username} has joined the channel.");
        }

        /// <summary>
        /// Called when a moderator has left the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnModeratorLeft(object sender, OnModeratorLeftArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Moderator {e.Username} has left the channel.");
        }

        private void Client_OnModeratorsReceived(object sender, OnModeratorsReceivedArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Moderators Received.");
        }

        private void Client_OnNoPermissionError(object sender, EventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] No Permission Error.");
        }

        /// <summary>
        /// Called when the channel is now hosting another channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnNowHosting(object sender, OnNowHostingArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Now hosting {e.HostedChannel}.");
            client.SendMessage(e.Channel, $"{e.Channel} is now hosting {e.HostedChannel}");
        }

        private void Client_OnRaidedChannelIsMatureAudience(object sender, EventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Raided Channel Is Mature Audience.");
        }

        /// <summary>
        /// Called when the channel is being raided by another channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            Console.WriteLine($"Channel raided by {e.Channel} with {e.RaidNotificaiton.MsgParamViewerCount} viewers.");
            client.SendMessage(e.Channel, $"Thank you {e.Channel} for raiding with {e.RaidNotificaiton.MsgParamViewerCount} viewers!");
        }

        /// <summary>
        /// Called when the Twitch bot client has reconnected to the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnReconnected(object sender, OnReconnectedEventArgs e)
        {
            Console.WriteLine($"Reconnected to the channel.");
        }

        /// <summary>
        /// Called when a viewer has become a returning subscriber.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            Console.WriteLine($"{e.ReSubscriber.DisplayName} has resubscribed {(e.ReSubscriber.SubscriptionPlan == TwitchLib.Client.Enums.SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
            client.SendMessage(e.Channel, $"{e.ReSubscriber.DisplayName} has resubscribed {(e.ReSubscriber.SubscriptionPlan == TwitchLib.Client.Enums.SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
        }

        private void Client_OnRitualNewChatter(object sender, OnRitualNewChatterArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Ritual New Chatter.");
        }

        private void Client_OnSelfRaidError(object sender, EventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Self Raid Error.");
        }

        private void Client_OnSendReceiveData(object sender, OnSendReceiveDataArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Send Receive Data.");
        }

        private void Client_OnUnaccountedFor(object sender, OnUnaccountedForArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Unaccounted For.");
        }

        /// <summary>
        /// Called when a viewer has been banned from chat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnUserBanned(object sender, OnUserBannedArgs e)
        {
            Console.WriteLine($"Banned the user {e.UserBan.Username}. Reason: {e.UserBan.BanReason}.");
            client.SendMessage(e.UserBan.Channel, $"Banned the user {e.UserBan.Username}. Reason: {e.UserBan.BanReason}.");
        }

        /// <summary>
        /// Called when a viewer has joined the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Viewer {e.Username} has joined the channel.");
        }

        /// <summary>
        /// Called when a viewer has left the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Viewer {e.Username} has left the channel.");
        }

        private void Client_OnUserStateChanged(object sender, OnUserStateChangedArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] User State Changed.");
        }

        /// <summary>
        /// Called when a viewer has been timed out from chat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnUserTimedout(object sender, OnUserTimedoutArgs e)
        {
            Console.WriteLine($"Timed out the user {e.UserTimeout.Username} for {e.UserTimeout.TimeoutDuration} seconds. Reason: {e.UserTimeout.TimeoutReason}.");
            client.SendMessage(e.UserTimeout.Channel, $"Timed out the user {e.UserTimeout.Username} for {e.UserTimeout.TimeoutReason} seconds. Reason: {e.UserTimeout.TimeoutReason}.");
        }

        /// <summary>
        /// Called when the bot has sent a whisper to another user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnWhisperSent(object sender, OnWhisperSentArgs e)
        {
            Console.WriteLine($"Sent a whisper to {e.Receiver}. Message: {e.Message}");
            client.SendWhisper(e.Receiver, e.Message);
        }

        private void Client_OnWhisperCommandReceived(object sender, OnWhisperCommandReceivedArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Whisper Command Received.");
        }

        private void Client_OnWhisperThrottled(object sender, OnWhisperThrottledEventArgs e)
        {
            Console.WriteLine($"[Unfinished Event Handler] Whisper Throttled.");
        }
    }
}