// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="NFluent">
//   Copyright 2018 Cyrille DUPUYDAUBY
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using NFluent;
using NUnit.Framework;

namespace ModernistTDD
{
    internal class ProgramShould
    {
        [Test]
        public static void
            ProduceGivenExample()
        {
            string result;
            var account = new Account();
            using (var capture = new Capture())
            {
                Clock.SetDate(2014, 4, 1);
                account.Deposit(1000);
                Clock.SetDate(2014, 4, 2);
                account.Withdraw(100);
                Clock.SetDate(2014, 4, 10);
                account.Deposit(500);
                account.PrintStatement();
                result = capture.ToString();
            }

            Check.That(result).AsLines().ContainsExactly("DATE | AMOUNT | BALANCE", "10/04/2014 | 500.00 | 1400.00",
                "02/04/2014 | -100.00 | 900.00", "01/04/2014 | 1000.00 | 1000.00");
        }

        [Test]
        public static void
            ProduceVariantExample()
        {
            string result;
            var account = new Account();
            using (var capture = new Capture())
            {
                Clock.SetDate(2014, 4, 1);
                account.Deposit(1000);
                Clock.SetDate(2014, 4, 2);
                account.Withdraw(200);
                Clock.SetDate(2014, 4, 10);
                account.Deposit(500);
                account.PrintStatement();
                result = capture.ToString();
            }

            Check.That(result).AsLines().ContainsExactly("DATE | AMOUNT | BALANCE", "10/04/2014 | 500.00 | 1300.00",
                "02/04/2014 | -200.00 | 800.00", "01/04/2014 | 1000.00 | 1000.00");
        }

        private static void Main(string[] args)
        {
        }
    }

    internal static class Clock
    {
        private static int year;
        private static int month;
        private static int day;
        
        public static void SetDate(int year, int month, int day)
        {
            Clock.year = year;
            Clock.month = month;
            Clock.day = day;
        }

        public static DateTime GetDate()
        {
            return new DateTime(year, month, day);
        }
    }
}