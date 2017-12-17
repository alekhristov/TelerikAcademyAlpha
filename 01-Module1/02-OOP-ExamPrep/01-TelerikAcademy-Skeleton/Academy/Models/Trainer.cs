using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    class Trainer : ITrainer
    {
        private string username;
        private IList<string> technologies;

        public Trainer(string username, IList<string> technologies)
        {
            this.Username = username;
            this.Technologies = new List<string>();
            this.Technologies = technologies;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value.Length < 3 || value.Length > 16) throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                this.username = value ?? throw new ArgumentNullException("You must enter a username!");
            }
        }
        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }
            set
            {
                this.technologies = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Trainer:");
            sb.AppendLine($" - Username: <{this.Username}>");
            sb.AppendLine($" - Technologies: {string.Join("; ", this.Technologies)}");

            return sb.ToString().TrimEnd();
        }
    }
}
