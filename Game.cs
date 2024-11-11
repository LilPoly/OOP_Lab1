namespace Lab1
{
    public class Game
    {
        private static uint _count_id = 1;
        public static List<Game> Games;
        public GameAccount Winner { get; }
        public GameAccount Loser { get; }
        public uint Score { get; }
        public uint Player_id;

        static Game()
        {
            Games = new List<Game>();
        }
        public Game(GameAccount winner, GameAccount loser, uint score)
        {
            Winner = winner;
            Loser = loser;
            Score = score;
            
            Player_id = _count_id++;
        }
        
        public static void GameHistory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game History:");
            foreach (var game in Games)
            {
                Console.WriteLine($"Game ID: {game.Player_id}: {game.Winner.UserName} won against {game.Loser.UserName} with a bet of {game.Score}.");
                Console.WriteLine($"Game ID: {game.Player_id}: {game.Loser.UserName} lost to {game.Winner.UserName} with a bet of {game.Score}.");
            }

        }
    }
}