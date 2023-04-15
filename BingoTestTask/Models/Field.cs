using BingoTestTask.Interfaces;

namespace BingoTestTask.Models
{
    public class Field : IBingoField
    {
        private List<FieldLine> lines;

        public Field(Configuration configuration)
        {
            this.lines = new List<FieldLine>();
            UniqueRandom random = new();
            int i = 0;
            while (i < configuration.Lines)
            {
                lines.Add(new FieldLine(random, configuration.Columns) { });
                i++;
            }
        }

        public void Draw()
        {
            foreach (FieldLine line in lines)
            {
                var numbers = line.GetNumbers();
                var closedColumnIndex = line.GetClosedColumns();
                for (int i = 0; i < 5; i++)
                {

                    Console.Write(@$"{(closedColumnIndex.Contains(i) ? "(": " ")}");
                    Console.Write(@$"{(numbers[i] > 9 ? "" : " " )}");
                    Console.Write(@$"{numbers[i]}");
                    Console.Write(@$"{(closedColumnIndex.Contains(i) ? ")": " ")}");
                }
                Console.Write("\n");
            }
            
        }

        public void CheckNumber(int number)
        {
            foreach (var line in lines) 
            {
                line.CheckNumber(number);
            }
        }

        public bool WinCondition()
        {
            if(IsAnyLineClosed() || IsAnyColumnClosed() || IsAnyDiagonalClosed())
            {
                return true;
            }

            return false;
        }

        private bool IsAnyLineClosed()
        {
            foreach (var line in lines)
            {
                if (line.IsLineChecked())
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsAnyColumnClosed()
        {
            foreach (var column in lines[0].GetClosedColumns())
            {
                var linesAmount = 0;

                foreach(var line in lines)
                {
                    if(!line.IsClosedColumn(column))
                    {
                        continue;
                    }
                    linesAmount++;
                }

                if(linesAmount == lines.Count())
                {
                    return true;
                }
            }

            return false;
        }
        private bool IsAnyDiagonalClosed()
        {
            var linesAmountLeft = 0;
            var linesAmountRight = 0;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].IsClosedColumn(i))
                {
                    linesAmountLeft++;
                }

                if (lines[i].IsClosedColumn(lines.Count() - i))
                {
                    linesAmountRight++;
                }
            }

            if (linesAmountLeft == lines.Count() || linesAmountRight == lines.Count())
            {
                return true;
            }

            return false;
        }
    }
}
