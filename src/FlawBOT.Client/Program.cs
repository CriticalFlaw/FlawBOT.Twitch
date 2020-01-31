using System;
using System.Reflection;

namespace FlawBOT
{
    public class Program
    {
        public static string Name { get; } = "FlawBOT";
        public static string Version { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string GitHubLink { get; set; } = "https://github.com/CriticalFlaw/FlawBOT-Twitch/";
        public static DateTime ProcessStarted { get; set; }

        private static void Main(string[] args)
        {
            var client = new TwitchClient();
            Console.ReadLine();
        }
    }
}