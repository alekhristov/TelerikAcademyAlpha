using Bytes2you.Validation;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Abstract
{
    public abstract class ListCommand
    {
        private readonly IDatabase database;

        public ListCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "Database").IsNull().Throw();
            this.database = database;
        }

        public IDatabase Database => this.database;
    }
}
