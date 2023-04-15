namespace BingoTestTask
{
    public class UniqueRandom
    {
        public static Random randomGenerator = new();

        private List<int> _selectedValues;

        public UniqueRandom()
        {
            _selectedValues = GenerateBoardValues();
        }

        private List<int> GenerateBoardValues()
        {
            _selectedValues = new();
            for (int i = 1; i <= 52; i++)
            {
                _selectedValues.Add(i);
            }

            return _selectedValues;
        }

        public int GetRandomValueAndRemoveSelected()
        {
            if (_selectedValues.Count == 0)
            {
                throw new ArgumentOutOfRangeException("All random numbers used.");
            }
            
            int takedIndex = randomGenerator.Next(0, _selectedValues.Count() - 1);
            var result = _selectedValues[takedIndex];
            _selectedValues.RemoveAt(takedIndex);

            return result;
        }
    }
}
