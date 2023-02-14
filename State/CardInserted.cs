namespace State;

public class CardInserted : State
{
    public CardInserted(Context context) : base(context)
    {
    }

    public override void InsertCard()
    {
        Console.WriteLine("You have already inserted a card");
    }

    public override void EjectCard()
    {
        Console.WriteLine("Card ejected");
        // _context change state to NoCard
    }

    public override void InsertPin(int pin)
    {
        if (pin == 8888)
        {
            Console.WriteLine("Correct PIN inserted");
            // _context change state to PinInserted
        }
        else
        {
            Console.WriteLine("Incorrect PIN inserted");
            Console.WriteLine("Card ejected");
            // _context change state to NoCard
        }
    }

    public override void WithdrawCash(int amount)
    {
        Console.WriteLine("Insert PIN first");
    }
}