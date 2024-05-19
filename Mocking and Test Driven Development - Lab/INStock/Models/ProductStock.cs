using INStock.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models;

public class ProductStock : IProductStock
{
    private List<IProduct> products;

    public ProductStock()
    {
        this.products = new List<IProduct>();
    }

    public int Count => products.Count;

    public IProduct this[int index]
    {
        get => products[index];
        set
        {
            products[index] = value;
        }
    }

    public void Add(IProduct product)
    {
        products.Add(product);
    }

    public bool Contains(IProduct product)
    {
        return products.Contains(product);
    }
    public bool Remove(IProduct product)
    {
        return products.Remove(product);
    }

    public IProduct Find(int index)
    {
        return products[index];
    }

    public IEnumerable<IProduct> FindAllByPrice(double price)
    {
        if (products.Count == 0)
        {
            throw new ArgumentException("Stock is empty");
        }

        IEnumerable<IProduct> currentProducts = this.products.Where(p => p.Price == (decimal)price);

        return currentProducts;
    }

    public IEnumerable<IProduct> FindAllByQuantity(int quantity)
    {
        if (products.Count == 0)
        {
            throw new ArgumentException("Stock is empty");
        }

        IEnumerable<IProduct> currentProducts = this.products.Where(p => p.Quantity == quantity);

        return currentProducts;
    }

    public IEnumerable<IProduct> FindAllInrangeAll(double lo, double hi)
    {
        if (products.Count == 0)
        {
            throw new ArgumentException("Stock is empty");
        }

        IEnumerable<IProduct> currentProducts = this.products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi);

        return currentProducts;
    }

    public IProduct FindByLabel(string label)
    {
        IProduct product = products.FirstOrDefault(p => p.Label == label);

        if (product is null)
        {
            throw new ArgumentException("Тhe product does not exist");
        }

        return product;

    }

    public IProduct FindMostExpensiveProduct()
    {
        IProduct product = products.OrderByDescending(p => p.Price).FirstOrDefault();

        if (product is null)
        {
            throw new ArgumentException("There are not products in stock");
        }

        return product;
    }

    public IEnumerator<IProduct> GetEnumerator()
    {
        foreach (IProduct product in products)
        {
            yield return product;
        }

        //return new StockEnumerator(products.ToArray());
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //private class StockEnumerator : IEnumerator<IProduct>
    //{
    //    private IProduct[] products;
    //    private int position = -1;

    //    public StockEnumerator(params IProduct[] products)
    //    {
    //        this.products = products;
    //    }

    //    public IProduct Current => products[position];

    //    object IEnumerator.Current => Current;

    //    public void Dispose()
    //    {

    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < products.Length);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }
}


