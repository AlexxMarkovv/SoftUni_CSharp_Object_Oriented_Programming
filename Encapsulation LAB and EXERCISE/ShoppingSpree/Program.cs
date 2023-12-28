namespace ShoppingSpree;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();
         
        try
        {
            string[] customersAndMoney = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < customersAndMoney.Length; i += 2)
            {
                Person person = new(customersAndMoney[i],
                    decimal.Parse(customersAndMoney[i + 1]));

                people.Add(person);
            }

            string[] productsAndCosts = Console.ReadLine()
               .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsAndCosts.Length; i += 2)
            {
                Product product = new(productsAndCosts[i],
                    decimal.Parse(productsAndCosts[i + 1]));

                products.Add(product);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] cmndArrgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = cmndArrgs[0];
            string nameOfProduct = cmndArrgs[1];

            Person person = people.FirstOrDefault(p => p.Name == name);
            Product product = products.FirstOrDefault(p => p.Name == nameOfProduct);

            if (person is not null && product is not null)
            {
                Console.WriteLine(person.AddProduct(product));
            }
        }

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}