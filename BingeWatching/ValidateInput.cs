using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BingeWatching
{
    public static class HandleInput
    {
        public static int handleRankRange()
        {
            bool success = false;
            int number;

            while (!success)
            {
                printToUser("Please rank the content 0-10");
                string input = Console.ReadLine();
                success = int.TryParse(input, out number);
                if (success)
                {
                    if (number >= 0 && number <= 10)
                        return number;
                    else
                        success = false;
                }

            }
            return 0;//should not be reached;

        }

        public static void handleLogin(bool fromSwitchUser=false)
        {
            
            while (Menu.currentUser == null || fromSwitchUser)//find current user
             {
            Console.WriteLine("Hi There! Please enter your name");
            Menu.currentUser = User.getUserByName(Console.ReadLine());
                fromSwitchUser = false;
            }
        }

        public static void HandleEndOfWatching()
        {
            bool flag = true;
            while (flag)
            {
                printToUser("Did You Finish Watching Y/N?");
                string choice = Console.ReadLine().ToUpper();
                if (choice != "N" && choice != "Y")
                    continue;
                if (choice.ToUpper() == "N")
                {
                    Thread.Sleep(2000);

                }
                else if (choice.ToUpper() == "Y")
                {
                    return;
                }

                }
        }


            public static void printToUser(string message)
        {
            Console.WriteLine($"Hi {Menu.currentUser.userName}, { message}");
        }
    }
}
