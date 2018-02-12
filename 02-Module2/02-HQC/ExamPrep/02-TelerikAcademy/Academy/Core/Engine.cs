using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser parser;
        private readonly ICommandProcessor processor;

        public Engine(IReader reader, IWriter writer, ICommandParser parser, ICommandProcessor processor)
        {
            Guard.WhenArgument(reader, "Reader").IsNull().Throw();
            Guard.WhenArgument(writer, "Writer").IsNull().Throw();
            Guard.WhenArgument(parser, "Parser").IsNull().Throw();
            Guard.WhenArgument(processor, "Processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    var executionResult = processor.ProcessCommand(commandAsString);
                    this.builder.AppendLine(executionResult);
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
