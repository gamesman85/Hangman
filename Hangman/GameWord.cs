using System;

namespace Hangman;

public class GameWord
{
    private readonly Random _random = new Random();
    private readonly string _randomWord;
    
    private static readonly string[] Words =
    {
        "paranoid",
        "waterfall",
        "mountain",
        "marshmallow",
        "euphoria"
    };

    public GameWord()
    {
        _randomWord = Words[_random.Next(Words.Length)];
    }

    public string GetWord()
    {
        return _randomWord;
    }
}