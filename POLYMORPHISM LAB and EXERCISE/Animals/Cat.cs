
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        //I am Peter and my fovourite food is Whiskas
        //MEEOW

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I am {Name} and my fovourite food is {FavoriteFood}");
            sb.Append("MEEOW");

            return sb.ToString();
        }
    }
}
