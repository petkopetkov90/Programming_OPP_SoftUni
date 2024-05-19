using System;

namespace INStock.Models.Contracts
{
    public interface IProduct : IComparable<IProduct>
    {
        string Label { get; }

        decimal Price { get; }

        int Quantity { get; }
    }
}
