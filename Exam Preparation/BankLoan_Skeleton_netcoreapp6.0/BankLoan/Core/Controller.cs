using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private readonly LoanRepository loans;
        private readonly BankRepository banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException("Invalid bank type.");
            }

            banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan;

            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException("Invalid loan type.");
            }

            loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            IBank bank = banks.FirstModel(bankName);

            bank.AddLoan(loan);
            loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName,
           string clientName, string id, double income)
        {
            IClient client;
            if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }
            else if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else
            {
                throw new ArgumentException("Invalid client type.");
            }

            IBank bank = banks.FirstModel(bankName);
            if (bank.GetType().Name == nameof(BranchBank) && client.GetType().Name == nameof(Adult)
                || bank.GetType().Name == nameof(CentralBank) && client.GetType().Name == nameof(Student))
            {
                return "Unsuitable bank.";
            }

            bank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }


        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);

            var clientsIncome = bank.Clients.Select(c => c.Income).Sum();

            //foreach (var client in bank.Clients)
            //{
            //    clientsIncome += client.Income;
            //}

            double loansAmounts = bank.Loans.Select(c => c.Amount).Sum();
            //foreach (var loan in bank.Loans)
            //{
            //    loansAmounts += loan.Amount;
            //}

            double funds = clientsIncome + loansAmounts;

            return $"The funds of bank {bankName} are {funds:f2}.";
        }


        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            var bankMoodels = banks.Models.ToList();

            foreach (var bank in bankMoodels)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
