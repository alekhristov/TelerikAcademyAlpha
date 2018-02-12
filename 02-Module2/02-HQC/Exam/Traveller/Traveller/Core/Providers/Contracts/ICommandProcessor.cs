namespace Traveller.Core.Providers.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string commandAsString);
    }
}
