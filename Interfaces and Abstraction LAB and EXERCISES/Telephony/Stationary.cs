
namespace Telephony
{
    public class Stationary : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!ValidateNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidateNumber(string phoneNumber)
            => phoneNumber.All(c => char.IsDigit(c));
    }
}
