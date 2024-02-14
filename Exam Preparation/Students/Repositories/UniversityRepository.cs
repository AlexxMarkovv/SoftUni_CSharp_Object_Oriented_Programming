using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository()
        {
            models = new();
        }

        private List<IUniversity> models;

        public IReadOnlyCollection<IUniversity> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IUniversity model)
        {
            University university = new(models.Count + 1, model.Name, model.Category
                , model.Capacity, model.RequiredSubjects.ToList());
            models.Add(university);
        }

        public IUniversity FindById(int id)
        {
            IUniversity subject = models.FirstOrDefault(x => x.Id == id);

            if (subject == null)
            {
                return null;
            }

            return subject;
        }

        public IUniversity FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }
    }
}
