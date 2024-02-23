using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        public LoanRepository()
        {
            models = new List<ILoan>();
        }

        private readonly List<ILoan> models;

        public IReadOnlyCollection<ILoan> Models
        {
            get { return models; }
            private set { }
        }


        public void AddModel(ILoan model)
        {
            models.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            return models.Remove(model);
        }

        public ILoan FirstModel(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);   
        }

        
    }
}
