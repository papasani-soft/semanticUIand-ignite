using Apache.Ignite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgntieDotnet
{
    class Program11
    {
        class Clientserdemo
        {
            static void Main(string[] args)
            {
                // Enable client mode locally.
                Ignition.ClientMode = true;

                // Start Ignite in client mode.
                IIgnite ignite = Ignition.Start();

                // Create cache on all the existing and future server nodes.
                // Note that since the local node is a client, it will not 
                // be caching any data.
                var cache = ignite.GetOrCreateCache<int, string>("anji");

                Console.WriteLine("cache  " + cache.Name);
                Console.WriteLine("complet");
                Console.ReadLine();


                //    var compute = ignite.GetCompute();

                //    while (true)
                //    {
                //        try
                //        {

                //            // compute.Run();
                //        }
                //        catch (ClientDisconnectedException e)
                //        {
                //            e.ClientReconnectTask.Wait(); // Wait for reconnection.

                //            // Can proceed and use the same ICompute instance.
                //        }
                //    }
            }
        }
    }
}
