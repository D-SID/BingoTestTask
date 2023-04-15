namespace BingoTestTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            Bingo bingo = new Bingo(CreateConfiguration());
            bingo.StartGame();
        }
        
        public static Configuration CreateConfiguration()
        {
            Configuration config = new();
            config.Lines = 5;
            config.Columns = 5;
            config.PlayersCount = 3;

            return config;
        }
    }
}