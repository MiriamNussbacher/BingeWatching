using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace BingeWatching
{
    public class User
    {
        public  string userName { get; set; }

    

        public   List<NetflixItem> historyItems { get; set; }
        private static List<User> users= new List<User>();


        public static void DisplayUserHistory()
        {
            if (Menu.currentUser.historyItems.Count == 0)
            {
                Console.WriteLine("You didn't watch anything yet. Try us out!");
                return;
            }
            Console.WriteLine($"{Menu.currentUser.userName} already watched:");
            foreach (NetflixItem item in Menu.currentUser.historyItems)
            {
                Console.Write($"{item.Title} | {item.ImdbRanking}  | {item.UserRanking}  | {item.Overview}  ");
            }
        }

        public static void InitUsers()
        {
         users= new List<User>

                {
                    new User { userName= "Miriam", historyItems=new List<NetflixItem>()},
                    new User { userName = "Donald Trump",historyItems=new List<NetflixItem>() },
                    new User { userName = "Joe Bidan",historyItems=new List<NetflixItem>() }
                };
    }

        internal static void Login(bool fromSwitchUser)
        {
            HandleInput.handleLogin(fromSwitchUser);
           // while (Menu.currentUser == null)//find current user
           // {
             //   Console.WriteLine("Hi There! Please enter your name");
               // Menu.currentUser = User.getUserByName(Console.ReadLine());
           // }

        }

        public static User getUserByName(string userName)
        {
           return users.FirstOrDefault(user => user.userName == userName);
        }

        public bool foundInHistory(Guid id)
        {
            List<NetflixItem> historyItems1 = Menu.currentUser.historyItems;
            var result= historyItems1.FirstOrDefault(item => item.id.CompareTo(id) > 0);
            return result == null;
        }

        public void saveToHistory(NetflixItem item)
        {
            historyItems.Add(item);
        }
    }

 
}
