using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        private decimal weekSalary;

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }

        private decimal workingHours;

        public decimal WorkingHours
        {
            get { return workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHours = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Name: ").Append(base.FirstName)
                .Append(Environment.NewLine)
                .Append("Last Name: ").Append(base.LastName)
                .Append(Environment.NewLine)
                .Append(String.Format("Week Salary: {0:F2}", this.WeekSalary))
                .Append(Environment.NewLine)
                .Append(String.Format("Hours per day: {0:F2}", this.WorkingHours))
                .Append(Environment.NewLine)
                .Append(String.Format("Salary per hour: {0:F2}", this.WeekSalary / (this.WorkingHours * 5)));

            return sb.ToString();
        }
    }
}
