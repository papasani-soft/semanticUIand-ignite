using Apache.Ignite.Core;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Discovery.Tcp.Static;
using Apache.Ignite.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgntieDotnet
{
    class Program12
    {
        static void Main(string[] args)
        {
            Ignition.Start(new IgniteConfiguration
            {
                DiscoverySpi = new TcpDiscoverySpi
                {
                    IpFinder = new TcpDiscoveryStaticIpFinder
                    {
                        Endpoints = new[] { "127.0.0.1:47500..47509" }
                    },
                    SocketTimeout = TimeSpan.FromSeconds(0.3)
                },
                IncludedEventTypes = EventType.CacheAll,
            });
            Console.WriteLine("success ");
            Console.ReadLine();
        }
    }
}
