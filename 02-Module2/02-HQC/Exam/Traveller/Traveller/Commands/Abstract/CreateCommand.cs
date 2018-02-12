using Bytes2you.Validation;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Abstract
{
    public abstract class CreateCommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDatabase database;

        public CreateCommand(ITravellerFactory factory, IDatabase database)
        {
            Guard.WhenArgument(factory, "Traveller factory").IsNull().Throw();
            Guard.WhenArgument(database, "Database").IsNull().Throw();

            this.factory = factory;
            this.database = database;
        }

        public ITravellerFactory Factory => this.factory;

        public IDatabase Database => this.database;
    }
}
