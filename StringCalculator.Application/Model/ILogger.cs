namespace StringCalculator.Application.Model
{
    public interface ILogger
    {
        public void AddEntry(string consoleInput, int calculatedString);
        public void AddErrorEntry(string consoleInput, string message);
    }
}