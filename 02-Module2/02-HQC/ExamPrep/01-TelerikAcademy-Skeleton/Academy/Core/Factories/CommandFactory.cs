using Academy.Commands.Contracts;
using Autofac;
using Bytes2you.Validation;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly ILifetimeScope container;

        public CommandFactory(ILifetimeScope container)
        {
            Guard.WhenArgument(container, "Container").IsNull().Throw();
            this.container = container;
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
