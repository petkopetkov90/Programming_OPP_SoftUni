using Composite.Models.Interefaces;

namespace Composite.Models;

public class CompositeGift : BaseGift, IGiftOperations
{
    private readonly List<BaseGift> gifts;

    public CompositeGift(string name, decimal price)
        : base(name, price)
    {
        gifts = new List<BaseGift>();
    }

    public override decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (BaseGift gift in gifts)
        {
            totalPrice += gift.CalculateTotalPrice();
        }

        return totalPrice;
    }

    public void Add(BaseGift gift)
    {
        gifts.Add(gift);
    }

    public void Remove(BaseGift gift)
    {
        gifts.Remove(gift);
    }
}
