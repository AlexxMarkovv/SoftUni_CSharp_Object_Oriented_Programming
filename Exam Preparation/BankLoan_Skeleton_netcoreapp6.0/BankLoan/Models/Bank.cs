using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        private List<ILoan> loans;

        public IReadOnlyCollection<ILoan> Loans
        {
            get { return loans; }
            private set { } 
        }

        private List<IClient> clients;

        public IReadOnlyCollection<IClient> Clients
        {
            get { return clients; }
            private set { }
        }

        public double SumRates()
        {
            return loans.Sum(l => l.InterestRate);
        }

        public void AddClient(IClient Client)
        {
            if (Capacity > 0)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            string availableClients = $"Clients: " +
                $"{(clients.Any() ? string.Join(", ", clients.Select(c => c.Name)) : "none")}";

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            sb.AppendLine($"{availableClients}");
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().TrimEnd();
        }
    }
}
