namespace CommandPattern
{
    public class Laptop
    {
        public int model;
        public int name;
        public int description;
        public int type;

        public Laptop(string name, string model, string description)
        {
            Name = name;
            Model = model;
            Description = description;
        }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }
    }
}
