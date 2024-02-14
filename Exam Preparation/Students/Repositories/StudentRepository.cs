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
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            models = new();
        }

        private List<IStudent> models;

        public IReadOnlyCollection<IStudent> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IStudent model)
        {
            Student student = new(models.Count + 1, model.FirstName, model.LastName);
            models.Add(student);
        }

        public IStudent FindById(int id)
        {
            IStudent subject = models.FirstOrDefault(x => x.Id == id);

            if (subject == null)
            {
                return null;
            }

            return subject;
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split();
            return models.FirstOrDefault(m => m.FirstName == names[0] && m.LastName == names[1]);
        }
    }
}
