
namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (!ValidateNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string website)
        {
            if (!ValidateURL(website))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }

        private bool ValidateNumber(string phoneNumber)
            => phoneNumber.All(c => char.IsDigit(c));

        private bool ValidateURL(string website)
            => website.All(c => !char.IsDigit(c));
    }
}
