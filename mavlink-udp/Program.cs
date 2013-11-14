using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Concurrent;

using MavLink;

namespace mavlinkudp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (!CheckArguments(args)) return;

            MavLinkUdpClient mluc = new MavLinkUdpClient
            {
                TargetIpAddress = new IPAddress(new byte[] { 127, 0, 0, 1 }),
                MavlinkSystemId = 187
            };

            mluc.OnPacketReceived += OnMavLinkPacketReceived;
            mluc.Initialize();
            mluc.BeginHeartBeatLoop();

            Console.WriteLine("Waiting for UDP...");
            Console.ReadLine();
        }

        static void OnMavLinkPacketReceived(object sender, MavlinkPacket e)
        {
            Console.WriteLine(e.Message);
        }

        private static bool CheckArguments(string[] args)
        {
            return true;
        }
    }
}
