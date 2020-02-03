using FlawBOT.Service;
using System;
using TwitchLib.Api;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace FlawBOT
{
    public class TwitchApp
    {
        private TwitchClient client;
        private TwitchAPI service;

        public TwitchApp()
        {
            // Initialize the Twitch API service.
            TokenService.LoadTokenList();
            service = new TwitchAPI();
            service.Settings.ClientId = TokenService.Tokens.ClientID;
            service.Settings.AccessToken = TokenService.Tokens.AccessToken;

            // Initialize the Twitch bot client.
            client = new TwitchClient();
            client.Initialize(new ConnectionCredentials(TokenService.Tokens.BotUsername, TokenService.Tokens.OAuth), TokenService.Tokens.ChannelName, '!', ',');

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
            //client.OnLog += Client_OnLog;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnMessageSent += Client_OnMessageSent;
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
            client.OnSelfRaidError += Client_OnSelfRaidError;
            //client.OnSendReceiveData += Client_OnSendReceiveData;
            //client.OnUnaccountedFor += Client_OnUnaccountedFor;
            client.OnUserBanned += Client_OnUserBanned;
            client.OnUserJoined += Client_OnUserJoined;
            client.OnUserLeft += Client_OnUserLeft;
            client.OnUserStateChanged += Client_OnUserStateChanged;
            client.OnUserTimedout += Client_OnUserTimedout;
            client.OnWhisperCommandReceived += Client_OnWhisperCommandReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnWhisperSent += Client_OnWhisperSent;
            client.Connect();

            // GET Methods
            //client.ChannelEmotes();
            //client.GetChannelModerators();
            //client.GetJoinedChannel();
            //client.IsConnected();
            //client.IsInitialized();
            //client.JoinedChannels();
            //client.PreviousWhisper();
        }

        /// <summary>
        /// Called when the channel is being hosted by another channel.
        /// </summary>
        private void Client_OnBeingHosted(object sender, OnBeingHostedArgs e)
        {
            Console.WriteLine($"[{e.BeingHostedNotification.Channel}] Channel is being hosted by {e.BeingHostedNotification.HostedByChannel}. ({e.BeingHostedNotification.Viewers} viewers)");
            client.SendMessage(e.BeingHostedNotification.Channel, $"Thank you {e.BeingHostedNotification.HostedByChannel} for the host!");
        }

        /// <summary>
        /// Called when the state of the channel has been changed.
        /// </summary>
        private void Client_OnChannelStateChanged(object sender, OnChannelStateChangedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Channel State Updated.");
        }

        /// <summary>
        /// Called when the Twitch chat has been cleared.
        /// </summary>
        private void Client_OnChatCleared(object sender, OnChatClearedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Chat Cleared.");
        }

        /// <summary>
        /// Called when the Twitch chat color has been changed.
        /// </summary>
        private void Client_OnChatColorChanged(object sender, OnChatColorChangedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Chat Color Updated.");
        }

        /// <summary>
        /// Called when the Twitch bot has received a command.
        /// </summary>
        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            Console.WriteLine($"Received Command: {e.Command.CommandText}");
            TimeSpan duration = DateTime.Now.AddMinutes(1) - DateTime.Now;

            switch (e.Command.CommandText.ToLowerInvariant())
            {
                case "ban":
                    BotService.BanUser(client, e.Command.ArgumentsAsString);
                    break;

                case "clear":
                    BotService.ClearChat(client);
                    break;

                case "color":
                    var random = new Random();
                    var colors = Enum.GetValues(typeof(ChatColorPresets));
                    BotService.ChangeChatColor(client, (ChatColorPresets)colors.GetValue(random.Next(colors.Length)));
                    break;

                case "disconnect":
                    BotService.Disconnect(client);
                    break;

                case "emote-off":
                    BotService.EmoteOnlyOff(client);
                    break;

                case "emote-on":
                    BotService.EmoteOnlyOn(client);
                    break;

                case "followers-off":
                    BotService.FollowersOnlyOff(client);
                    break;

                case "followers-on":
                    duration = DateTime.Now.AddMinutes(int.Parse(e.Command.ArgumentsAsString)) - DateTime.Now;
                    BotService.FollowersOnlyOn(client, duration);
                    break;

                case "host":
                    BotService.Host(client, e.Command.ArgumentsAsString);
                    break;

                case "join":
                    BotService.JoinChannel(client);
                    break;

                case "join-room":
                    BotService.JoinRoom(client, e.Command.ArgumentsAsString);
                    break;

                case "leave":
                    BotService.LeaveChannel(client);
                    break;

                case "leave-room":
                    BotService.LeaveRoom(client, e.Command.ArgumentsAsString);
                    break;

                case "mod":
                    BotService.Mod(client, e.Command.ArgumentsAsString);
                    break;

                case "raid":
                    BotService.Raid(client, e.Command.ArgumentsAsString);
                    break;

                case "reconnect":
                    BotService.Reconnect(client);
                    break;

                case "reply":
                    BotService.ReplyToLastWhisper(client, e.Command.ArgumentsAsString);
                    break;

                case "send":
                    BotService.SendMessage(client, e.Command.ArgumentsAsString);
                    break;

                case "send-q":
                    BotService.SendQueuedItem(client, e.Command.ArgumentsAsString);
                    break;

                case "send-r":
                    BotService.SendRaw(client, e.Command.ArgumentsAsString);
                    break;

                case "whisper":
                    BotService.SendWhisper(client, e.Command.ArgumentsAsList[0], e.Command.ArgumentsAsString);
                    break;

                case "slowmo-off":
                    BotService.SlowModeOff(client);
                    break;

                case "slowmo-on":
                    duration = DateTime.Now.AddMinutes(int.Parse(e.Command.ArgumentsAsString)) - DateTime.Now;
                    BotService.SlowModeOn(client, duration);
                    break;

                case "commercial":
                    BotService.StartCommercial(client, CommercialLength.Seconds60);
                    break;

                case "subs-off":
                    BotService.SubscribersOnlyOff(client);
                    break;

                case "subs-on":
                    BotService.SubscribersOnlyOn(client);
                    break;

                case "timeout":
                    duration = DateTime.Now.AddMinutes(int.Parse(e.Command.ArgumentsAsList[1])) - DateTime.Now;
                    BotService.TimeoutUser(client, e.Command.ArgumentsAsList[0], duration, e.Command.ArgumentsAsList[2]);
                    break;

                case "unban":
                    BotService.UnbanUser(client, e.Command.ArgumentsAsString);
                    break;

                case "unhost":
                    BotService.Unhost(client);
                    break;

                case "unmod":
                    BotService.Unmod(client, e.Command.ArgumentsAsString);
                    break;
            }
        }

        private void Client_OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Community Subscription.");
        }

        /// <summary>
        /// Called when the Twitch bot has connected to the channel.
        /// </summary>
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"[{e.AutoJoinChannel}] {e.BotUsername} has auto-joined the channel.");
            client.SendMessage(e.AutoJoinChannel, $"{e.BotUsername} has connected to {e.AutoJoinChannel}.");
        }

        /// <summary>
        /// Called when the Twitch bot was unable to connect to the channel.
        /// </summary>
        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"[ERROR] {e.BotUsername} was unable to connect to the channel. {e.Error.Message}");
        }

        /// <summary>
        /// Called when the Twitch bot has disconnected from the channel.
        /// </summary>
        private void Client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            Console.WriteLine($"{Program.Name} has been disconnected.");
        }

        /// <summary>
        /// Called when an exception error has occurred.
        /// </summary>
        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            Console.WriteLine($"[ERROR] {e.Exception.Message}");
        }

        private void Client_OnExistingUsersDetected(object sender, OnExistingUsersDetectedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.Users.Count} existing users detected.");
        }

        private void Client_OnFailureToReceiveJoinConfirmation(object sender, OnFailureToReceiveJoinConfirmationArgs e)
        {
            Console.WriteLine($"[{e.Exception.Channel}] Failed to receive join confirmation. {e.Exception.Details}");
        }

        /// <summary>
        /// Called when someone was gifted a subscription to the channel.
        /// </summary>
        private void Client_OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.GiftedSubscription.DisplayName} has gifted a subscription to {e.GiftedSubscription.MsgParamRecipientDisplayName}.");
            client.SendMessage(e.Channel, $"{e.GiftedSubscription.DisplayName} has gifted a subscription to {e.GiftedSubscription.MsgParamRecipientDisplayName}.");
        }

        /// <summary>
        /// Called when the channel has started hosting another channel.
        /// </summary>
        private void Client_OnHostingStarted(object sender, OnHostingStartedArgs e)
        {
            Console.WriteLine($"[{e.HostingStarted.HostingChannel}] Now hosting {e.HostingStarted.TargetChannel} with {e.HostingStarted.Viewers} viewers.");
            client.SendMessage(e.HostingStarted.HostingChannel, $"Now hosting {e.HostingStarted.TargetChannel} with {e.HostingStarted.Viewers} viewers.");
        }

        /// <summary>
        /// Called when the channel has stopped hosting another channel.
        /// </summary>
        private void Client_OnHostingStopped(object sender, OnHostingStoppedArgs e)
        {
            Console.WriteLine($"[CHANNEL] Stopped hosting {e.HostingStopped.HostingChannel}.");
        }

        private void Client_OnHostLeft(object sender, EventArgs e)
        {
            Console.WriteLine($"[CHANNEL] The host has left.");
        }

        private void Client_OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            Console.WriteLine($"[ERROR] Incorrect Login. {e.Exception.Message}");
        }

        /// <summary>
        /// Called when the Twitch bot has joined a channel.
        /// </summary>
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.BotUsername} has joined the channel.");
            client.SendMessage(e.Channel, $"{e.BotUsername} has joined the channel.");
        }

        /// <summary>
        /// Called when the Twitch bot has left the channel.
        /// </summary>
        private void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.BotUsername} has left the channel.");
            client.SendMessage(e.Channel, $"{e.BotUsername} is leaving the channel.");
        }

        /// <summary>
        /// Called when a loggable event has occurred.
        /// </summary>
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: [{e.BotUsername}] {e.Data}");
        }

        /// <summary>
        /// Called when a new Twitch chat message has been received.
        /// </summary>
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.StartsWith("hello", StringComparison.InvariantCultureIgnoreCase))
                client.SendMessage(e.ChatMessage.Channel, $"Hello {e.ChatMessage.Username}. Welcome to the channel.");
            if (e.ChatMessage.Message.Contains("badword"))
                BotService.TimeoutUser(client, e.ChatMessage.Username, TimeSpan.FromMinutes(30), $"{e.ChatMessage.Username} you can't say that! You are now timed out for 30 minutes!");
        }

        /// <summary>
        /// Called when the Twitch bot has sent a chat message.
        /// </summary>
        private void Client_OnMessageSent(object sender, OnMessageSentArgs e)
        {
            Console.WriteLine($"[{e.SentMessage.Channel}] {e.SentMessage.DisplayName} has sent a message: {e.SentMessage.Message}");
        }

        /// <summary>
        /// Called when a moderator has joined the channel.
        /// </summary>
        private void Client_OnModeratorJoined(object sender, OnModeratorJoinedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Moderator {e.Username} has joined the channel.");
        }

        /// <summary>
        /// Called when a moderator has left the channel.
        /// </summary>
        private void Client_OnModeratorLeft(object sender, OnModeratorLeftArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Moderator {e.Username} has left the channel.");
        }

        private void Client_OnModeratorsReceived(object sender, OnModeratorsReceivedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Moderators Received.");
        }

        /// <summary>
        /// Called when a viewer has become a new subscriber.
        /// </summary>
        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.Subscriber.DisplayName} has subscribed {(e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
            client.SendMessage(e.Channel, $"{e.Subscriber.DisplayName} has subscribed {(e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
        }

        /// <summary>
        /// Called when a permissions error has occurred.
        /// </summary>
        private void Client_OnNoPermissionError(object sender, EventArgs e)
        {
            Console.WriteLine($"[ERROR] Insufficient Permissions.");
        }

        /// <summary>
        /// Called when the channel is now hosting another channel.
        /// </summary>
        private void Client_OnNowHosting(object sender, OnNowHostingArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Now hosting {e.HostedChannel}.");
            client.SendMessage(e.Channel, $"{e.Channel} is now hosting {e.HostedChannel}");
        }

        /// <summary>
        /// Called when the it's detected that the raided channel is intended for mature audiences.
        /// </summary>
        private void Client_OnRaidedChannelIsMatureAudience(object sender, EventArgs e)
        {
            Console.WriteLine($"[WARNING] Raided Channel Is Mature Audience.");
        }

        /// <summary>
        /// Called when the channel is being raided by another channel.
        /// </summary>
        private void Client_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            Console.WriteLine($"[{e.Channel}] Raided the channel with {e.RaidNotification.MsgParamViewerCount} viewers.");
            client.SendMessage(e.Channel, $"Thank you {e.Channel} for raiding with {e.RaidNotification.MsgParamViewerCount} viewers!");
        }

        /// <summary>
        /// Called when the Twitch bot client has reconnected to the channel.
        /// </summary>
        private void Client_OnReconnected(object sender, OnReconnectedEventArgs e)
        {
            Console.WriteLine($"Reconnected to the channel.");
        }

        /// <summary>
        /// Called when a viewer has become a returning subscriber.
        /// </summary>
        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.ReSubscriber.DisplayName} has resubscribed {(e.ReSubscriber.SubscriptionPlan == SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
            client.SendMessage(e.Channel, $"{e.ReSubscriber.DisplayName} has resubscribed {(e.ReSubscriber.SubscriptionPlan == SubscriptionPlan.Prime ? "using Twitch Prime" : "")}.");
        }

        private void Client_OnSelfRaidError(object sender, EventArgs e)
        {
            Console.WriteLine($"[ERROR] Self Raid.");
        }

        private void Client_OnSendReceiveData(object sender, OnSendReceiveDataArgs e)
        {
            Console.WriteLine($"[NOTICE] Sending Receive {e.Direction}: {e.Data}.");
        }

        private void Client_OnUnaccountedFor(object sender, OnUnaccountedForArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.BotUsername} unaccounted for {e.RawIRC} in {e.Location}.");
        }

        /// <summary>
        /// Called when a viewer has been banned from chat.
        /// </summary>
        private void Client_OnUserBanned(object sender, OnUserBannedArgs e)
        {
            Console.WriteLine($"[{e.UserBan.Channel}] Banned the user {e.UserBan.Username}. Reason: {e.UserBan.BanReason}.");
            client.SendMessage(e.UserBan.Channel, $"Banned the user {e.UserBan.Username}. Reason: {e.UserBan.BanReason}.");
        }

        /// <summary>
        /// Called when a viewer has joined the channel.
        /// </summary>
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.Username} has joined the channel.");
        }

        /// <summary>
        /// Called when a viewer has left the channel.
        /// </summary>
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            Console.WriteLine($"[{e.Channel}] {e.Username} has left the channel.");
        }

        /// <summary>
        /// Called when the user state has been updated.
        /// </summary>
        private void Client_OnUserStateChanged(object sender, OnUserStateChangedArgs e)
        {
            Console.WriteLine($"[{e.UserState.DisplayName}] User State Updated.");
        }

        /// <summary>
        /// Called when a viewer has been timed out from chat.
        /// </summary>
        private void Client_OnUserTimedout(object sender, OnUserTimedoutArgs e)
        {
            Console.WriteLine($"[{e.UserTimeout.Channel}] Timed out the user {e.UserTimeout.Username} for {e.UserTimeout.TimeoutDuration} seconds. Reason: {e.UserTimeout.TimeoutReason}.");
            client.SendMessage(e.UserTimeout.Channel, $"Timed out the user {e.UserTimeout.Username} for {e.UserTimeout.TimeoutReason} seconds. Reason: {e.UserTimeout.TimeoutReason}.");
        }

        /// <summary>
        /// Called when the Twitch bot has sent a whisper to another user.
        /// </summary>
        private void Client_OnWhisperSent(object sender, OnWhisperSentArgs e)
        {
            Console.WriteLine($"[{Program.Name}] Sent a whisper to {e.Receiver}. Message: {e.Message}");
            client.SendWhisper(e.Receiver, e.Message);
        }

        /// <summary>
        /// Called when the Twitch bot has received a command through a whisper.
        /// </summary>
        private void Client_OnWhisperCommandReceived(object sender, OnWhisperCommandReceivedArgs e)
        {
            Console.WriteLine($"[{Program.Name}] Received Whisper Command: {e.Command.WhisperMessage}");
        }

        /// <summary>
        /// Called when the Twitch bot has received a whisper from another user.
        /// </summary>
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == TokenService.Tokens.ChannelName)
                client.SendWhisper(e.WhisperMessage.Username, "Hello!");
            Console.WriteLine($"[{e.WhisperMessage.BotUsername}] Received Whisper From {e.WhisperMessage.DisplayName} ({e.WhisperMessage.UserId}). {e.WhisperMessage.Message}");
        }
    }
}