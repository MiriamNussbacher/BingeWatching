namespace BingeWatching
{
    public interface IMenuStateHandler
    {
        bool CanHandle(MenuState menuState);
        void Handle();
    }
}