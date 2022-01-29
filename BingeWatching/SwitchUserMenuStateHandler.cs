namespace BingeWatching
{
    public class SwitchUserMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.SwitchUser;
        }

        public void Handle()
        {
            User.Login(true);
        }
    }
}