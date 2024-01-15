namespace CommandPattern
{
    public class Mouse
    {
        public Mouse(string model, int precision)
        {
            Model = model;
            Precision = precision;
        }

        public string Model { get; set; }

        public int Precision { get; set; }

        [Obsolete]
        public void MouseMethod()
        {

        }

        [Obsolete]
        public void MouseUp() { }


        public void NormalMethod() { }

    }
}
