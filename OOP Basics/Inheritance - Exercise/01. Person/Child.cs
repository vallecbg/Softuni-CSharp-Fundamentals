using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string Name
        {
            get { return base.Name; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                base.Name = value;
            }
        }

        public override int Age
        {
            get
            {
                return base.Age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }


    }
}
