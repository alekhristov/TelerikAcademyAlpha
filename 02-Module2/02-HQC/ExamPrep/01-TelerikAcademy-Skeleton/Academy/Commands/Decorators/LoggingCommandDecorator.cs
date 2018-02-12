using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Providers;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Text;

namespace Academy.Commands.Decorators
{
    public class LoggingCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IWriter writer;

        public LoggingCommandDecorator(ICommand command, IWriter writer)
        {
            Guard.WhenArgument(command, "Command").IsNull().Throw();
            this.command = command;
            this.writer = writer;
        }

        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Command is called at {DateTimeProvider.Now}!");
            sb.Append(this.command.Execute(parameters));

            return sb.ToString();
        }
    }
}
