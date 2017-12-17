using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Academy.Commands.Listing
{
    class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            if (engine.Trainers.Count == 0 && engine.Students.Count == 0)
            {
                return "There are no registered users!";
            }

            var sb = new StringBuilder();

            foreach (var trainer in this.engine.Trainers)
            {
                sb.AppendLine(trainer.ToString());
            }

            foreach (var student in this.engine.Students)
            {
                sb.AppendLine(student.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
