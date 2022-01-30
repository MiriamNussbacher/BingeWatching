namespace BingeWatching
{
    public interface IHandleInput
    {
        void HandleEndOfWatching();
        void handleLogin(bool fromSwitchUser = false);
        int handleRankRange();
        void printToUser(string message);
    }
}