namespace Lab1
{
    class Game
    {
        private static uint _count_id = 1;
        internal static List<Game> Games;
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
    }
}