namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; }
        private uint CurrentRating { get; set; } = 1;
        private uint GamesCount { get; set; }

        private List<Game> gameList;

        public GameAccount(string username)
        {
            UserName = username;

            gameList = new List<Game>();
        }

        public void WinGame(GameAccount opponentName, uint rating)
        {
            Game game = new Game(this, opponentName, rating);
            if (rating < 1)
            {
                throw new InvalidOperationException("Enter a number greater than 1");
            }
            
            CurrentRating += rating;

            opponentName.CurrentRating = opponentName.CurrentRating > rating ? opponentName.CurrentRating - rating : 1;

            GamesCount += 1;

            gameList.Add(game);
            opponentName.gameList.Add(game);

            Game.Games.Add(game);

        }

        public void LoseGame(GameAccount opponentName, uint rating)
        {
            Game game = new Game(opponentName, this, rating);
            
            if (rating < 1)
            {
                throw new InvalidOperationException("Enter a number greater than 1");
            }

            CurrentRating = CurrentRating > rating ? CurrentRating - rating : 1;
            
            opponentName.CurrentRating += rating;
            
            GamesCount += 1;
            
            gameList.Add(game);
            opponentName.gameList.Add(game); 
        
            Game.Games.Add(game);
        }
        
        public void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Stats of {UserName}");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("─────────────────────────────────────");
            Console.WriteLine($"{"Metric",-15} | {"Value",-10}");
            Console.WriteLine("─────────────────────────────────────");
            
            Console.WriteLine($"{ "Current rating:",-15} | {CurrentRating,-10}");
            Console.WriteLine($"{ "Games played:",-15} | {gameList.Count,-10}");
            Console.WriteLine($"{ "Wins:",-15} | {gameList.Count(i => i.Winner == this),-10}");
            Console.WriteLine($"{ "Defeats:",-15} | {gameList.Count(i => i.Loser == this),-10}");
    
            Console.WriteLine("─────────────────────────────────────");
            Console.ResetColor();
        }


    }
    
}