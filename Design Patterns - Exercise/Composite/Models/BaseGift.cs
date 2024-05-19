namespace Composite.Models;

public abstract class BaseGift
{
    protected string name;
    protected decimal price;

    protected BaseGift(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }

    public abstract decimal CalculateTotalPrice();
}
