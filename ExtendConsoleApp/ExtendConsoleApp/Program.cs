namespace ExtendConsoleApp
{
    class PrivateClass
    {
        private int Age { get; set; }

        public void Console()
        {
            this.Age = 1;
        }
    }

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var privateClass = new PrivateClass();
            privateClass.
        }
    }
}