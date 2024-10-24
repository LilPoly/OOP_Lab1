namespace Lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var John = new GameAccount("John");
            var Steve = new GameAccount("Steve");
            
            var Michael = new GameAccount("Michael");
            var Jack = new GameAccount("Jack");
            
            John.WinGame(Steve, 5);
            John.WinGame(Steve, 12);
            
            Steve.WinGame(Jack, 3);
            
            John.GetStats();
            Steve.GetStats();
            
            Michael.LoseGame(Jack, 5);
            
            Michael.GetStats();
            Jack.GetStats();

            Game.GameHistory();

        }
    }
}