namespace StringCalculator.Application.Model
{
    public interface Logger
    {
        public void AddEntry(string consoleInput, int calculatedString);
        public void AddErrorEntry(string consoleInput, string message);
    }
}