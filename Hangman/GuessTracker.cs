namespace Hangman;

public class GuessTracker
{
    private readonly GameWord _gameWord;
    private string _correctGuesses = "";
    private string _incorrectGuesses = "";

    public GuessTracker(GameWord gameWord)
    {
        _gameWord = gameWord;
    }

    public string IncorrectGuesses => _incorrectGuesses;
    public int IncorrectGuessCount => _incorrectGuesses.Length;

    public bool MakeGuess(char letter)
    {
        letter = char.ToLower(letter);

        if (_correctGuesses.Contains(letter) || _incorrectGuesses.Contains(letter))
        {
            // Already guessed
            return false;
        }

        if (_gameWord.GetWord().Contains(letter))
        {
            _correctGuesses += letter;
            return true;
        }
        else
        {
            _incorrectGuesses += letter;
            return false;
        }
    }

    public string GetWordProgress()
    {
        return _gameWord.GetHyphenatedWord(_correctGuesses);
    }

    public bool IsWordComplete()
    {
        return !_gameWord.GetHyphenatedWord(_correctGuesses).Contains("_");
    }
}