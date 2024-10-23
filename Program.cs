namespace Lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var John = new GameAccount("John");
            var Steve = new GameAccount("Steve");
            
            John.WinGame(Steve, 5);
            John.WinGame(Steve, 12);
            
            John.GetStats();
            Steve.GetStats();
        }
    }
}