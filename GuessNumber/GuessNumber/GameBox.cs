using System;

namespace GuessNumber
{
    public class GameBox
    {
        private readonly IGameView _gameView;

        public GameBox(IGameView gameView)
        {
            _gameView = gameView;
        }

        public int NumberToBeGuessed;

        private void Introduction()
        {
            string message = "Hey, Let's play a game! " + "\nYou should just guess the number setted by me. " +
                "\nNumber is in range from 0 to 100. " + "\nIf you will enter something different from number, you'll see just warning text " +
                "\n... but remember that Big Brother watches you! (-_-)" + "\nIf you devine, you will have +1 to your karma," +
                "\n..in case if you will enter wrong number," + "\nI'll display you a tooltip, and you will have other attemsts to guess and win the game." +
                "\nLET's GO! I've already set the number. Try to guess it!" + "\n\nGood luck, man !";

            _gameView.DisplayMessage(message);
        }

        public void PlayGame()
        {
            Introduction();

            while (true)
            {
                NumberToBeGuessed = new Random().Next(0, 101);

                while (!TryProccessNumber(GetValidNumber())) { }

                _gameView.DisplayMessage("Whould you like to play again? Print \"yes\" if do, and \"no\" if don't.");
                if (!PlayAgain(_gameView.GetUserResponse()))
                {
                    break;
                }
            }
        }

        private bool TryProccessNumber(int userNumber)
        {
            switch (userNumber.CompareTo(NumberToBeGuessed))
            {
                case 1:
                    _gameView.DisplayMessage("Your number is bigger than mine. Try again...");
                    return false;
                case -1:
                    _gameView.DisplayMessage("Your number is smaller than mine. Try again...");
                    return false;
                case 0:
                    _gameView.DisplayMessage("Congrats! You won the game.");
                    return true;
                default:
                    return false;
            }
        }

        private bool PlayAgain(string userResponse)
        {
            if (string.IsNullOrEmpty(userResponse))
                return false;

            if (userResponse.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                _gameView.DisplayMessage("LET's GO! I've already set the number. Try to guess it again!");
                return true;
            }

            if (userResponse.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                _gameView.DisplayMessage("Thank you for game! Bye!");
                return false;
            }
            return false;
        }

        private int GetValidNumber()
        {
            int userNumber;
            while (!int.TryParse(_gameView.GetUserResponse(), out userNumber))
            {
                _gameView.DisplayMessage("Oh Man, you are wrong. Please enther a valid number!");
            }
            return userNumber;
        }
    }
}