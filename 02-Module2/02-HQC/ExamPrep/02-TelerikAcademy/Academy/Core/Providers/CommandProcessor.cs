using Academy.Core.Contracts;
using System;

namespace Academy.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
        {
            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            return command.Execute(parameters);
        }
    }
}
