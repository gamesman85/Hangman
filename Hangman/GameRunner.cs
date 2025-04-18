namespace Hangman;

using System;
public class GameRunner
{
    public static void Run()
    {
        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine();
        
        GameWord gameWord = new GameWord();
        GuessTracker guessTracker = new GuessTracker(gameWord);
        GameState gameState = new GameState();
        char lastGuess = ' ';
        
        // Display initial state
        DisplayWordState(gameWord, guessTracker);
        DisplayStatLine(guessTracker, gameState, lastGuess);
        
        // Game loop
        while (!gameState.IsGameOver(guessTracker))
        {
            // Get user input
            lastGuess = GetUserGuess();
            
            // Process guess
            bool isNewGuess = guessTracker.MakeGuess(lastGuess);
            
            if (!isNewGuess)
            {
                Console.WriteLine($"You already chose {lastGuess}, pick again.");
                continue;
            }
            
            // Display updated word
            DisplayWordState(gameWord, guessTracker);
            DisplayStatLine(guessTracker, gameState, lastGuess);
        }
        
        // Game outcome
        if (gameState.IsPlayerWinner(guessTracker))
        {
            Console.WriteLine("You won!");
        }
        else
        {
            Console.WriteLine("You lost!");
            Console.WriteLine($"The word was: {gameWord.GetWord()}");
        }
    }
    
    private static void DisplayWordState(GameWord gameWord, GuessTracker guessTracker)
    {
        string progress = guessTracker.GetWordProgress();
        Console.WriteLine($"Word: {progress}");
    }
    
    private static void DisplayStatLine(GuessTracker guessTracker, GameState gameState, char lastGuess)
    {
        int remaining = gameState.GetRemainingGuesses(guessTracker);
        string guessDisplay = lastGuess == ' ' ? "" : lastGuess.ToString();
        Console.WriteLine($"| Remaining: {remaining} | Incorrect: {guessTracker.IncorrectGuesses} | Guess: {guessDisplay}");
    }
    
    private static char GetUserGuess()
    {
        char guess;
        bool validInput = false;
        
        do
        {
            string input = Console.ReadLine() ?? string.Empty;
            
            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                guess = char.ToLower(input[0]);
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                guess = '\0';
            }
        } while (!validInput);
        
        return guess;
    }
}