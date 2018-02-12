using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "Command factory").IsNull().Throw();
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "Full command").IsNullOrEmpty().Throw();

            var commandName = fullCommand.Split()[0];
            var command = commandFactory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "Full command").IsNullOrEmpty().Throw();

            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
