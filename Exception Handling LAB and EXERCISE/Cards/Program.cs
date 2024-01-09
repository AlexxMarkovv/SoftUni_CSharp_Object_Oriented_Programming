

string[] input = Console.ReadLine()
    .Split(", ");

List<string> result = new List<string>();

for (int i = 0; i < input.Length; i++)
{
    string[] currPair = input[i].Split(" ");

    try
    {
        string face = GetCardFace(currPair[0]);
        CardSuit cardSuit = GetCardSuit(currPair[1]);

        Card card = new Card(face, cardSuit);

        result.Add(card.ToString());
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(" ", result));

static CardSuit GetCardSuit(string v)
{
    switch (v)
    {
        case "S": return CardSuit.Spade;
        case "H": return CardSuit.Heart;
        case "D": return CardSuit.Diamond;
        case "C": return CardSuit.Club;
        default:
            throw new ArgumentException("Invalid card!");
    }
}

static string GetCardFace(string v)
{
    switch (v)
    {
        case "2": return "2";
        case "3": return "3";
        case "4": return "4";
        case "5": return "5";
        case "6": return "6";
        case "7": return "7";
        case "8": return "8";
        case "9": return "9";
        case "10": return "10";
        case "J": return "J";
        case "Q": return "Q";
        case "K": return "K";
        case "A": return "A";
        default:
            throw new ArgumentException("Invalid card!");
    }
}

public class Card
{
    public Card(string cardFace, CardSuit cardSuit)
    {
        CardFace = cardFace;
        CardSuit = cardSuit;
    }

    public string CardFace { get; set; }

    public CardSuit CardSuit { get; set; }

    public override string ToString()
    {
        char viewSuit = '\u2660';

        switch (this.CardSuit)
        {
            case CardSuit.Club:
                viewSuit = '\u2663';
                break;
            case CardSuit.Diamond:
                viewSuit = '\u2666';
                break;
            case CardSuit.Heart:
                viewSuit = '\u2665';
                break;
            default:
                break;
        }

        return $"[{CardFace}{viewSuit}]";
    }
}

//public enum CardFace
//{
//    two = 0,
//    three = 1,
//    four = 2,
//    five = 3,
//    six = 4,
//    seven = 5,
//    eight = 6,
//    nine = 7,
//    ten = 8, 
//    Jack = 9,
//    Queen = 9,
//    King = 10,
//    Ace = 11,
//}

public enum CardSuit
{
    Club = 0,
    Diamond = 1,
    Heart = 2,
    Spade = 3,
}