
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I am {Name} and my fovourite food is {FavoriteFood}");
            sb.Append("DJAAF");

            return sb.ToString();
        }
    }
}
