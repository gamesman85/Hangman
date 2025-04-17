namespace Hangman;

public class GameWord
{
    private readonly Random _random = new Random();
    private readonly string _randomWord;
    
    private static readonly string[] _words =
    {
        "paranoid",
        "waterfall",
        "mountain",
        "marshmallow",
        "euphoria"
    };

    public GameWord()
    {
        _randomWord = _words[_random.Next(_words.Length)];
    }

    public string GetWord()
    {
        return _randomWord;
    }
}