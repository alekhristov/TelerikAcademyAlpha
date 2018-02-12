namespace OlympicGames.Core.Contracts
{
    public interface IIoWrapper
    {
        void WriteWithWrapper(string msg);

        string ReadWithWrapper();
    }
}
