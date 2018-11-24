using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgntieDotnet
{
    class Program9Car1
    {
        [QuerySqlField] public string Model { get; set; }
        [QuerySqlField] public int Power { get; set; }


        static void Main(string[] args)
        {

            try
            {
                var ignite = Ignition.Start();
              
                var queryEntity = new QueryEntity(typeof(int), typeof(Program9Car1));
                var cacheConfig = new CacheConfiguration("cars1", queryEntity);
                ICache<int, Program9Car1> cache = ignite.GetOrCreateCache<int, Program9Car1>(cacheConfig);

               
                var insertQuery = new SqlFieldsQuery("INSERT INTO Car1 (_key, Model, Power) VALUES " +
                                                "(11, 'Ariel Atom', 350), " +
                                                "(21, 'Reliant Robin', 39)");
                cache.QueryFields(insertQuery).GetAll();

               
                var selQuery = new SqlQuery(typeof(Program9Car1), "SELECT * FROM Car1 ORDER BY Power");
                foreach (ICacheEntry<int, Program9Car1> entry in cache.Query(selQuery))
                    Console.WriteLine(entry);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
