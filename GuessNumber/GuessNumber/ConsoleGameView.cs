using System;

namespace GuessNumber
{
    public class ConsoleGameView : IGameView
    {
        public virtual void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string GetUserResponse()
        {
            return Console.ReadLine();
        }
    }
}
