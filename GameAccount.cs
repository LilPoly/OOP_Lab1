namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; }
        public uint CurrentRating { get; set; } = 1;
        public uint GamesCount { get; set; }

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
                throw new InvalidOperationException("Enter a number greter than 1");
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
                throw new InvalidOperationException("Enter a number greter than 1");
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
            Console.WriteLine($"Current rating: {CurrentRating}");
            Console.WriteLine($"Games played: {gameList.Count}");
            Console.WriteLine($"Wins: {gameList.Count(i => i.Winner == this)}");
            Console.WriteLine($"Defeats: {gameList.Count(i => i.Loser  == this)}");
        
            Console.ResetColor();
        }

    }
    
}