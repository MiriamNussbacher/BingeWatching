namespace BingeWatching
{
    public class HistoryMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.History;
        }

        public void Handle()
        {
            User.DisplayUserHistory();
        }
    }
}