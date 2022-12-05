using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodaLibrary.NodaHelpers.Diagnostic
{
    public static class Counter
    {
        public static Dictionary<String, int>? dictionnary;


        private static void CreateNewIfNotExist(String KeyName)
        {
            if (dictionnary == null)
                dictionnary = new Dictionary<string, int>();

            if (!dictionnary.ContainsKey(KeyName))
            {
                dictionnary.Add(KeyName, 0);
                dictionnary = dictionnary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public static void Increment(String KeyName)
        {
            CreateNewIfNotExist(KeyName);

            if (dictionnary.ContainsKey(KeyName))
            {
                dictionnary[KeyName] = dictionnary[KeyName] + 1;
                Console.WriteLine("|----DEBUG INSTANCE----| " + KeyName.PadRight(35) + "| Ajout d'instance");
            }
        }

        public static void Decrement(String KeyName)
        {
            if (dictionnary.ContainsKey(KeyName))
            {
                dictionnary[KeyName] = dictionnary[KeyName] - 1;
                Console.WriteLine("|----DEBUG INSTANCE----| " + KeyName.PadRight(35) + "| Destruction d'instance");
            }
        }
        public static void Log(String KeyName = "")
        {
            
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            if (String.IsNullOrWhiteSpace(KeyName))
            {
                foreach (var item in dictionnary)
                {
                    Console.WriteLine("|----DEBUG INSTANCE----| " + item.Key.PadRight(35) + "| Nombre d'instance : " + item.Value);
                }
            }
            else
            {
                Console.WriteLine("|----DEBUG INSTANCE----| " + KeyName.PadRight(35) + "| Nombre d'instance : " + dictionnary[KeyName]);
            }


            Console.WriteLine("|----DEBUG INSTANCE----| MEMORY : " + (GC.GetTotalMemory(false) / 8) / 1048576 + " Mo");
            Console.WriteLine("|----DEBUG INSTANCE----| MEMORY after collection : " + (GC.GetTotalMemory(true) / 8) / 1048576 + " Mo");

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            
        }

    }
}
