using System;
using System.Text;

namespace Hangman;

public class GameWord
{
    private readonly Random _random = new Random();
    private readonly string _randomWord;
    
    private static readonly string[] Words =
    {
        "immutable",
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

    public string GetHyphenatedWord(string lettersToShow)
    {
        StringBuilder text = new StringBuilder();
        
        foreach (char letter in _randomWord)
        {
            if (lettersToShow.Contains(letter))
            {
                text.Append(letter + " ");
            }
            else
            {
                text.Append("- ");
            }
        }

        return text.ToString().Trim();
    }
}