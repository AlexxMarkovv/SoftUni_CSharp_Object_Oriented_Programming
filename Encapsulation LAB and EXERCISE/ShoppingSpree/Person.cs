
namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Money cannot be negative");
                }

                money = value;
            }
        }

        public List<Product> BagOfProducts
        {
            get { return products; }

            set { products = value; }
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            Money -= product.Cost;

            products.Add(product);

            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            IEnumerable<string> productNames = products.Select(p => p.Name);

            string productsString = products.Any()
                ? string.Join(", ", productNames)
                : "Nothing bought";

            return $"{Name} - {productsString}";
        }
    }
}
