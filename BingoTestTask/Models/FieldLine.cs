namespace BingoTestTask.Models
{
    public class FieldLine
    {
        private List<int> _numbers = new();
        private List<int> _closedColumns = new();

        public FieldLine(UniqueRandom randGenerator, int lineSize)
        {
            while (lineSize > _numbers.Count())
            {
                _numbers.Add(randGenerator.GetRandomValueAndRemoveSelected());
            }
        }

        public bool CheckNumber(int number)
        {
            var index = _numbers.FindIndex(x => x == number);
            if (index == -1)
            {
                return false;
            }

            if (_closedColumns.Contains(index))
            {
                throw new Exception("Number was duplicated.");
            }
            _closedColumns.Add(index);

            return true;
        }
        public bool IsLineChecked()
        {
            if (_closedColumns.Count() == _numbers.Count())
            {
                return true;
            }
            return false;
        }
        public bool IsClosedColumn(int column)
        {
            return _closedColumns.Contains(column);
        }
        public List<int> GetClosedColumns()
        {
            return _closedColumns;
        }

        public List<int> GetNumbers()
        {
            return _numbers;
        }
    }
}
