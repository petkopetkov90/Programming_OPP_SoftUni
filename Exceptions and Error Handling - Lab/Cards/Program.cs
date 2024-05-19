
string[] cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

List<Card> validCards = new List<Card>();

for (int i = 0; i < cards.Length; i++)
{
    string cardFace = cards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
    string cardSuit = cards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

    try
    {
        validCards.Add(CreateCard(cardFace, cardSuit));
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}


Console.WriteLine(string.Join(" ", validCards));


Card CreateCard(string cardFace, string cardSuit)
{
    return new Card(cardFace, cardSuit);
}

public class Card
{
    private readonly List<string> faces = new List<string>() { { "2" }, { "3" }, { "4" }, { "5" }, { "6" }, { "7" }, { "8" }, { "9" }, { "10" }, { "J" }, { "Q" }, { "K" }, { "A" } };
    private readonly Dictionary<string, string> suits = new Dictionary<string, string>() { { "S", "\u2660" }, { "H", "\u2665" }, { "D", "\u2666" }, { "C", "\u2663" } };
    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get
        {
            return face;
        }
        private set
        {
            if (!faces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            face = value;
        }
    }
    public string Suit
    {
        get
        {
            return suit;
        }
        private set
        {
            if (!suits.ContainsKey(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            suit = suits[value];
        }
    }

    public override string ToString()
    {
        return $"[{face}{suit}]";
    }
}