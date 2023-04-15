namespace BingoTestTask.Interfaces
{
    public interface IBingoField
    {
        public void Draw();
        public bool WinCondition();
        public void CheckNumber(int number);
    }
}
