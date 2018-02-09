# Outside-In TDD

Learn and practice the double loop of TDD. Test software modules from the outside, identifying the side effects.

## Problem description

Create a simple bank application with the following features:

- Deposit into Account
- Withdraw from an Account
- Print a bank statement to the console

All of the methods must be void and you cannot add anymore methods to the Account class.

## Acceptance criteria

Statement should have transactions in the following format:

- DATE | AMOUNT | BALANCE
- date | amount | balance

The scenario for the kata is as follows:

- Given a client makes a deposit of 1000 on 01-04-2014 
- And a withdrawal of 100 on 02-04-2014 
- And a deposit of 500 on 10-04-2014 
- When she prints her bank statement Then she would see

The output should look like the following:

- DATE | AMOUNT | BALANCE
- 10/04/2014 | 500.00 | 1400.00
- 02/04/2014	 | -100 | 900.00
- 01/04/2014	 | 1000.00	 | 1000.00
