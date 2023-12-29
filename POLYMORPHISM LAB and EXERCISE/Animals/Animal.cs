
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavoriteFood = favouriteFood;
        }

        protected string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string FavoriteFood
        {
            get { return favouriteFood; }
            private set { favouriteFood = value;}
        }

        public abstract string ExplainSelf();
    }
}
