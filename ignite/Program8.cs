using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgntieDotnet
{
    class Program8
    {
        class Car
        {
            public string Model { get; set; }
            public int Power { get; set; }
            public override string ToString() => $"Model: {Model}, Power: {Power} hp";


            static void Main()
            {
                using (var ignite = Ignition.Start())
                {
                    ICache<int, Car> cache = ignite.GetOrCreateCache<int, Car>("cars");
                    cache[1] = new Car { Model = "Pagani Zonda R", Power = 740 };
                    cache[2] = new Car { Model = "Honda ", Power = 800 };
                    cache[3] = new Car { Model = "hundai", Power = 1000 };
                    cache[4] = new Car { Model = "Pagani Zonda R", Power = 740 };

                    foreach (ICacheEntry<int, Car> entry in cache)
                        Console.WriteLine(entry);
                }
                Console.ReadLine();
            }

        }
    }
}
