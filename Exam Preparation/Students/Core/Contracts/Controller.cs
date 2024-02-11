using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core.Contracts
{
    public class Controller : IController
    {
        private string[] allowedCategories = new string[]
        { "TechnicalSubject", "EconomicalSubject", "HumanitySubject" };
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            if (!allowedCategories.Contains(subjectType))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            Subject subject = null;
            if (subjectType == typeof(TechnicalSubject).Name)
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            else if (subjectType == typeof(EconomicalSubject).Name)
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            else if (subjectType == typeof(HumanitySubject).Name)
            {
                subject = new HumanitySubject(0, subjectName);
            }

            subjects.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully,
                subject.GetType().Name, subjectName, subjects.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            students.AddModel(new Student(0, firstName, lastName));

            return string.Format(OutputMessages.StudentAddedSuccessfully,
                firstName, lastName, students.GetType().Name);
        }


        public string AddUniversity(string universityName, string category,
            int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsAsInts = requiredSubjects.Select(x =>
            subjects.FindByName(x).Id).ToList();

            University university = new(0, universityName, category, capacity, requiredSubjectsAsInts);

            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully,
                universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] names = studentName.Split();
            IStudent student = students.FindByName($"{names[0]} {names[1]}");

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered,
                    student.FirstName, student.LastName);
            }

            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var requieredExams in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(requieredExams))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams,
                    studentName, universityName);
                }
            }

            if (student.University != null && student.University.Name == university.Name)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined,
                    names[0], names[1], universityName);
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined,
                    names[0], names[1], universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);

            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam,
                    student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam,
                student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder stringBuilder = new StringBuilder();

            int admittedStudents = CountStudentsInUni(university);
            stringBuilder.AppendLine($"*** {university.Name} ***");
            stringBuilder.AppendLine($"Profile: {university.Category}");
            stringBuilder.AppendLine($"Students admitted: {admittedStudents}");
            stringBuilder.AppendLine($"University vacancy: {university.Capacity - admittedStudents}");

            return stringBuilder.ToString().Trim();
        }

        private int CountStudentsInUni(IUniversity university)
        {
            int count = 0;
            foreach (var student in students.Models)
            {
                if (student.University?.Id == university.Id)
                {
                    count++;
                }
            }

            return count;
        }   
    }
}
