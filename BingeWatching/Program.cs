using System;

namespace BingeWatching
{
    public sealed class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to Netflix Binge watching service.");
                new Menu().Run();
                Console.WriteLine("Goodbye, see you again soon.");
            }
            catch(Exception ex)
            {
                //write to logger;
                Console.WriteLine("An Error Occoured, Please try Later!");
            }
        }
    }
}