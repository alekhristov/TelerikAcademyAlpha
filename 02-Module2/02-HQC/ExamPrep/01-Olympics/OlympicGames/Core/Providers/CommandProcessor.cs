using OlympicGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IIoWrapper ioWrapper;

        public CommandProcessor(IIoWrapper ioWrapper)
        {
            this.Commands = new List<ICommand>();
            this.ioWrapper = ioWrapper;
        }

        public ICollection<ICommand> Commands { get; private set; }

        public void ProcessSingleCommand(ICommand command, string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = command.Execute(lineParameters);
            var normalizedOutput = this.NormalizeOutput(result);
            ioWrapper.WriteWithWrapper(normalizedOutput);
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}