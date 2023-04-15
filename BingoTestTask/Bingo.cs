using BingoTestTask.Interfaces;
using BingoTestTask.Models;

namespace BingoTestTask
{
    internal class Bingo 
    {
        private List<IBingoField> fields = new();
        private UniqueRandom random = new();
        public Bingo(Configuration configuration)
        {
            for(int i = 0; i < configuration.PlayersCount; i++)
            {
                fields.Add(new Field(configuration));
            }
        }
        public void StartGame()
        {
            bool gameEnded = false;
            int i = 1;
            while(!gameEnded)
            {
                Console.Clear();
                var number = random.GetRandomValueAndRemoveSelected();
                Console.WriteLine($@"Step: {i++} |  Next value: {number}");
                foreach (var field in fields)
                {
                    field.CheckNumber(number);
                    Console.WriteLine($"\nPlayer {fields.IndexOf(field) + 1}: card.");
                    field.Draw();
                    if (field.WinCondition())
                    {
                        gameEnded = true;
                        Console.WriteLine(@$"Player {fields.IndexOf(field)}: BINGO!!!");
                    }
                }
                Console.WriteLine("Press q for Exit   |   Press 'Enter' to take next value");
                if (Console.ReadLine() == "q")
                {
                    break;
                }
            }
        }
    }
}
