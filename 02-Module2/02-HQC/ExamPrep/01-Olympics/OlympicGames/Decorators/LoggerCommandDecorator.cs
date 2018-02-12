using OlympicGames.Core.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Decorators
{
    public class LoggerCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IIoWrapper ioWrapper;

        public LoggerCommandDecorator(ICommand command, IIoWrapper ioWrapper)
        {
            this.command = command;
            this.ioWrapper = ioWrapper;
        }

        public string Execute(IList<string> commandLine)
        {
            ioWrapper.WriteWithWrapper("DECORATOR!DECORATOR!DECORATOR!DECORATOR!DECORATOR!DECORATOR!");
            var result = this.command.Execute(commandLine);

            return result;
        }
    }
}
