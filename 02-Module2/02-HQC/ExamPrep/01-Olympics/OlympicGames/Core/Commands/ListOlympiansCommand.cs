using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        private string key;
        private string order;

        public ListOlympiansCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        public override string Execute(IList<string> commandLine)
        {
            if (commandLine == null || commandLine.Count == 0)
            {
                this.key = "firstname";
                this.order = "asc";
            }
            else if (commandLine.Count == 1)
            {
                this.key = commandLine[0];
                this.order = "asc";
            }
            else
            {
                if (commandLine[1].ToLower() != "asc" && commandLine[1].ToLower() != "desc")
                {
                    this.order = "asc";
                }
                else
                {
                    this.order = commandLine[1];
                }
                this.key = commandLine[0];
            }
            var stringBuilder = new StringBuilder();
            var sorted = this.Committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                stringBuilder.AppendLine(GlobalConstants.NoOlympiansAdded);
                return stringBuilder.ToString();
            }

           // stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

            if (this.order.ToLower().Trim() == "desc")
            {
                sorted = this.Committee.Olympians.OrderByDescending(x => x.FirstName).ToList();
            }
            else
            {
                sorted = this.Committee.Olympians.OrderBy(x => x.FirstName).ToList();
            }

            foreach (var item in sorted)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
