using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public abstract class CreateOlympianCommand : Command
    {
        public CreateOlympianCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected string FirstName { get; private set; }

        protected string LastName { get; private set; }

        protected string Country { get; private set; }

        public override string Execute(IList<string> commandLine)
        {
            commandLine.ValidateIfNull();

            if (commandLine.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.FirstName = commandLine[0];
            this.LastName = commandLine[1];
            this.Country = commandLine[2];

            var olympian = this.CreatePerson();

            this.Committee.Olympians.Add(olympian);

            return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        }

        protected abstract IOlympian CreatePerson();
    }
}
