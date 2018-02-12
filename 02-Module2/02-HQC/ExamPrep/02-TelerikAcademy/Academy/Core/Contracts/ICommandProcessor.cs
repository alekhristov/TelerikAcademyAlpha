namespace Academy.Core.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string commandAsString);
    }
}
