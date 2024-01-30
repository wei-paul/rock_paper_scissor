using System.Diagnostics;
using System.Text;

namespace Tutorial;

class Program
{
    public static string[] hand = {"Rock", "Paper", "Scissor"};
    static void Main(string[] args)
    {
        Program program = new Program();
        introductionParagraph();
        string humanInput = Console.ReadLine();
        Console.WriteLine($"You have input: {humanInput}");
        Console.WriteLine("Rock, Paper, Scissor!");
        string computerInput = generateHand(hand);
        Console.WriteLine($"You chose {humanInput}. Computer chose {computerInput}");
        string result = compareHands(humanInput, computerInput);
        Console.WriteLine(result);
    }

    public static void introductionParagraph()
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissor!");
        Console.WriteLine("Please press enter to read the following rules");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Enter) 
        {
            Console.WriteLine("Please type one of the following: \"Rock\", \"Paper\", \"Scissor\"");
        }
    }

    static string generateHand(string[] hand)
    {
        Random random = new Random();
        string s = hand[random.Next(0, hand.Length)];
        return s;
    }
    
    static string compareHands(string humanInput, string computerInput)
    {
        humanInput = humanInput.ToLower();
        computerInput = computerInput.ToLower();
        Console.WriteLine($"Human input is: {humanInput}");
        Console.WriteLine($"Computer input is: {computerInput}");

        if (humanInput == computerInput) 
        {
            return "It's a tie!";
        }
        else
        {
            string result = determineWinner(humanInput, computerInput);
            return result;
        }
    }
    
    static string determineWinner(string human, string computer)
    {
        switch(human)
        {
            case "rock":
                return evaluateChoice(human, computer, "scissor", "paper");
            case "paper":
                return evaluateChoice(human, computer, "rock", "scissor");
            case "scissor":
                return evaluateChoice(human, computer, "paper", "rock");
            default:
                return "Invalid input, please choose \"Rock\", \"Paper\", \"Scissor\"";
        }
    }

    static string evaluateChoice(string human, string computer, string winnerChoice, string loserChoice)
    {
        if (computer == winnerChoice) 
        {
            return "Congratulations! You won!";
        }
        else if (computer == loserChoice)
        {
            return "YOU ARE GOMI, MAKEDA!";
        }
        else 
        {
            return "Invalid Input";
        }
    }
}
