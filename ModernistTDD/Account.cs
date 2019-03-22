using System;
using System.Collections.Generic;

namespace ModernistTDD
{
    public class Account
    {
        private IList<Tuple<DateTime, int>> operations = new List<Tuple<DateTime, int>>();

        public void Deposit(int amount)
        {
            this.operations.Add(new Tuple<DateTime, int>(Clock.GetDate(), amount));
        }

        public void Withdraw(int amount)
        {
            this.operations.Add(new Tuple<DateTime, int>(Clock.GetDate(), -amount));
        }

        public void PrintStatement()
        {
            IList<string> output = new List<string>();
            Console.WriteLine("DATE | AMOUNT | BALANCE");
            var balance = 0;
            for(var i = 0 ; i < this.operations.Count; i++)
            {
                var operation = this.operations[i];
                balance += operation.Item2;
                output.Add($"{operation.Item1:dd/MM/yyyy} | {operation.Item2:F2} | {balance:F2}");
            }

            for (int i = output.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
