using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase database;

        public ListUsersInSeasonCommand(IAcademyFactory factory, IDatabase database)
        {
            Guard.WhenArgument(factory, "Factory").IsNull().Throw();
            Guard.WhenArgument(database, "Engine").IsNull().Throw();

            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.database.Seasons[int.Parse(seasonId)];

            return season.ListUsers().TrimEnd();
        }
    }
}
