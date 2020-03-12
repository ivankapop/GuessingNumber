namespace GuessNumber
{
    public interface IGameView
    {
        void DisplayMessage(string message);
        string GetUserResponse();
    }
}
