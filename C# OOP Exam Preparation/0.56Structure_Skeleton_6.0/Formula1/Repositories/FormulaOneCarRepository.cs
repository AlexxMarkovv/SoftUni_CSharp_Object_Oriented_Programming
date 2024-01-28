using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public FormulaOneCarRepository()
        {
            formulaOneCars = new List<IFormulaOneCar>();
        }

        private List<IFormulaOneCar> formulaOneCars;

        public IReadOnlyCollection<IFormulaOneCar> Models => this.formulaOneCars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            formulaOneCars.Add(model);
        }

        public IFormulaOneCar FindByName(string model)
        {
            return formulaOneCars.FirstOrDefault(x => x.Model == model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return formulaOneCars.Remove(model);
        }
    }
}
