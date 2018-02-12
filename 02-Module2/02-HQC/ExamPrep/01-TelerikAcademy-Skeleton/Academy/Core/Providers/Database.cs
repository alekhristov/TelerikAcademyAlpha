using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly List<ISeason> seasons;
        private readonly List<IStudent> students;
        private readonly List<ITrainer> trainers;

        public Database()
        {
            this.seasons = new List<ISeason>();
            this.students = new List<IStudent>();
            this.trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons => this.seasons;

        public IList<IStudent> Students => this.students;

        public IList<ITrainer> Trainers => this.trainers;
    }
}
