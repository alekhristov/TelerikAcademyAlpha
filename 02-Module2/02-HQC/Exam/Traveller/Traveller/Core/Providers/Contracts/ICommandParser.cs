using System.Collections.Generic;
using Traveller.Commands.Contracts;

namespace Traveller.Core.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
