using Bytes2you.Validation;
using System;
using System.Text;
using Traveller.Core.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private StringBuilder Builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor processor;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandProcessor processor)
        {
            Guard.WhenArgument(reader, "Reader").IsNull().Throw();
            Guard.WhenArgument(writer, "Writer").IsNull().Throw();
            Guard.WhenArgument(processor, "Processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        writer.Write(this.Builder.ToString());
                        break;
                    }

                    var executionResult = this.processor.ProcessCommand(commandAsString);
                    this.Builder.AppendLine(executionResult);
                }
                catch (Exception ex)
                {
                    this.Builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
