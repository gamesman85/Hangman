namespace Hangman;

using System;
public class GameRunner
{
    public static void Run()
    {
        GameWord gameWord = new GameWord();
        GuessTracker guessTracker = new GuessTracker(gameWord);
    }
}