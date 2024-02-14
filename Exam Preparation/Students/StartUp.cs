namespace UniversityCompetition
{
    using System;
    using UniversityCompetition.Core;
    using UniversityCompetition.Core.Contracts;
    using UniversityCompetition.Models;
    using UniversityCompetition.Repositories;

    public class StartUp
    {
        static void Main()
        {
            //SubjectRepository repo = new SubjectRepository();

            //repo.AddModel(new TechnicalSubject(555, "test"));
            //repo.AddModel(new TechnicalSubject(555, "test"));
            //repo.AddModel(new TechnicalSubject(555, "test"));
            //repo.AddModel(new TechnicalSubject(555, "test"));
            //repo.AddModel(new TechnicalSubject(555, "test"));

            //foreach (var item in repo.Models)
            //{
            //    Console.WriteLine(item.Id);
            //}

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
