namespace Composite.Models;

public class SingleGift : BaseGift
{
    public SingleGift(string name, decimal price)
        : base(name, price)
    {
    }

    public override decimal CalculateTotalPrice() => price;
}
