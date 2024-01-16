
namespace DocumentationAttributes
{
    [Documentation("Product is a class that represents a product!")]

    internal class Product
    {
        [Documentation(Documentation = "Print method is a method that prints the product! " +
            "It is void and accepts 0 parameters!")]

        public void PrintProduct()
        {

        }
    }
}
