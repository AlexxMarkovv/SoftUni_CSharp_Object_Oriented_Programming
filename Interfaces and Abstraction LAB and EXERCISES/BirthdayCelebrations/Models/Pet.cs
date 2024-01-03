using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Pet : ICelebratable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthdate = birthday;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
