namespace Hangman;

public class GameState
{
    private const int MaxIncorrectGuesses = 5;
    
    public bool IsGameOver(GuessTracker guessTracker)
    {
        return IsPlayerWinner(guessTracker) || IsPlayerLoser(guessTracker);
    }
    
    public bool IsPlayerWinner(GuessTracker guessTracker)
    {
        return guessTracker.IsWordComplete();
    }
    
    public bool IsPlayerLoser(GuessTracker guessTracker)
    {
        return guessTracker.IncorrectGuessCount >= MaxIncorrectGuesses;
    }
    
    public int GetRemainingGuesses(GuessTracker guessTracker)
    {
        return MaxIncorrectGuesses - guessTracker.IncorrectGuessCount;
    }
}