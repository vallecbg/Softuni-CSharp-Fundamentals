using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
        {
            this.accounts = accounts;
        }

        public decimal GetBalance()
        {
            return this.accounts.Select(a => a.Balance).Sum();
        }
    }
}
