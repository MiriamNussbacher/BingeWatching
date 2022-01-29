using System;

namespace BingeWatching
{
    public class ExitMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Exit;
        }

        public void Handle()
        {
            Console.WriteLine("Good Bye, Miriam!");
            Environment.Exit(0);
        }
    }
}