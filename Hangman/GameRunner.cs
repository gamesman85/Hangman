namespace Hangman;

using System;
public class GameRunner
{
    public static void Run()
    {
        GameWord gameWord = new GameWord();
        Console.WriteLine(gameWord.GetWord());
        Console.WriteLine(gameWord.GetHyphenatedWord("aei"));
    }
}