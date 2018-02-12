using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase database;

        public ListUsersCommand(IAcademyFactory factory, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            if (database.Trainers.Count == 0 && database.Students.Count == 0)
            {
                return "There are no registered users!";
            }

            var sb = new StringBuilder();

            foreach (var trainer in this.database.Trainers)
            {
                sb.AppendLine(trainer.ToString());
            }

            foreach (var student in this.database.Students)
            {
                sb.AppendLine(student.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
