using RealmSqlStudio.RealmSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.Prompt
{
    public static class InteractivePrompt
    {
        private static string[] finishInteraction = new string[] {"exit","quit",";q", ";q!", "q" };

        public static void Start()
        {
            var realmFile = new RealmFilePath();
            Console.Write("please input absolute resource older:");
            realmFile.ResourcePath = Console.ReadLine();
            Console.Write("please input car code:");
            realmFile.CarCode = Console.ReadLine();
            while (true)
            {
                Console.Write(">");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (finishInteraction.Contains(input))
                {
                    return;
                }
                if ("reload".Equals(input.Trim()))
                {
                    realmFile.Reload();
                    continue;
                }
                try
                {
                    var result = new InputSql(input, realmFile).Analyze();
                    Console.WriteLine(result);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Exception:{e.Message}");
                    Console.WriteLine("If you want finish, you need to input 'q' or Ctrl + c");
                    Console.WriteLine("If you want reload realm file, you need to input 'reload'");
                }
            }
        }
    }
}
