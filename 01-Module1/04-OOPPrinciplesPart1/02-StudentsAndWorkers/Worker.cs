using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_StudentsAndWorkers
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary { get; set; }

        public double WorkHoursPerDay { get; set; }

        public override string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public double MoneyPerHour()
        {
            return (WeekSalary / 5) / WorkHoursPerDay;
        }
    }
}
