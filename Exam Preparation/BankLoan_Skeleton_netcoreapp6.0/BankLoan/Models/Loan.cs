﻿using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        public Loan(int interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }

        private int interestRate;

        public int InterestRate
        {
            get { return interestRate; }
            private set { interestRate = value; }
        }


        private double amount;

        public double Amount
        {
            get { return amount; }
            private set { amount = value; }
        }

    }
}
