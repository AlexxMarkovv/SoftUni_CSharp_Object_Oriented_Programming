
namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private int power = 80;
        public Druid(string name, int power) : base(name, power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            set
            {
                power = value;
            }
        }
    }
}
