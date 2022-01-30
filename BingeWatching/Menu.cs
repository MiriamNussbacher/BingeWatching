using System;
using System.Collections.Generic;
using System.Linq;

namespace BingeWatching
{
    public sealed class Menu
    {
        public static User currentUser;
      //  public static User user = new User();

        private readonly IList<IMenuStateHandler> _menuStateHandlers = new List<IMenuStateHandler>
        {
            new ContentMenuStateHandler(),
            new SwitchUserMenuStateHandler(),
            new HistoryMenuStateHandler(),
            new ExitMenuStateHandler()
        };

        public void Run()
        { 

            while (true)
            {
                User.InitUsers();//init users into memory
                User.Login(false);
                var menuState = GetMenuState();

                var handler = _menuStateHandlers.FirstOrDefault(h => h.CanHandle((MenuState)menuState));
                if (handler == null)
                    throw new NotImplementedException();

                handler.Handle();
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
            }
        }

        private /*MenuState*/ Enum GetMenuState()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Binge Watching menu");
                Console.WriteLine("---------------------------------------------------------------------");

                Console.Write("|  ");
                var allMenuStates = GetAllPossibleMenuStates();
                foreach (MenuState menuState in allMenuStates)
                {
                    Console.Write($"{Char.ToLower((char) menuState)} - {menuState}  |  ");
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Hit the relevant menu key.");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var menuStateChoice = (MenuState) Enum.ToObject(typeof(MenuState), choice);
                if (allMenuStates.Contains(menuStateChoice))
                {
                    return menuStateChoice;
                }

                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        public /*MenuState*/ Enum GetMenuByParam()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Binge Watching menu");
                Console.WriteLine("---------------------------------------------------------------------");

                Console.Write("|  ");
                var allMenuStates = GetAllPossibleMenuStates();
                foreach (MenuState menuState in allMenuStates)
                {
                    Console.Write($"{Char.ToLower((char)menuState)} - {menuState}  |  ");
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Hit the relevant menu key.");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var menuStateChoice = (Enum)Enum.ToObject(typeof(Enum), choice);
                //if (allMenuStates.Contains(menuStateChoice))
                //{
                //    return menuStateChoice;
                //}

                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        private Enum[] GetAllPossibleMenu<T>(T enum1) =>
           (Enum[])Enum.GetValues(typeof(T));

        private MenuState[] GetAllPossibleMenuStates() =>
            (MenuState[]) Enum.GetValues(typeof(MenuState));
    }
}