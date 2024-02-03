using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }

        private readonly List<IVessel> vessels;
        public IReadOnlyCollection<IVessel> Models => vessels.AsReadOnly();

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(x => x.Name == name);
        }
    }
}
