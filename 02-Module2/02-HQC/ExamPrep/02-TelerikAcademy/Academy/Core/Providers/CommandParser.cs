using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Core.Providers
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
            var commandName = fullCommand.Split(' ')[0].ToLower();
            var command = commandFactory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').Skip(1).ToList();

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
