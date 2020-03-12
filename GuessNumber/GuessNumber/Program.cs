namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBox = new GameBox(new ConsoleGameView());

            gameBox.PlayGame();
        }
    }
}
