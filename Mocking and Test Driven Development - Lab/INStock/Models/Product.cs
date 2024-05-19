using INStock.Models.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public int CompareTo(IProduct other)
        {
            int result = this.Price.CompareTo(other.Price);

            if (result == 0)
            {
                result = this.Quantity.CompareTo(other.Quantity);

                if (result == 0)
                {
                    result = this.Label.CompareTo(other.Label);
                }
            }

            return result;
        }
    }
}
