
namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer : INamable
    {
        public int Food { get;}

        void BuyFood();
    }
}
