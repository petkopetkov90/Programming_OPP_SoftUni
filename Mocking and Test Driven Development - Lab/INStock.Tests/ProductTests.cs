using INStock.Models;
using INStock.Models.Contracts;
using NUnit.Framework;

namespace INStock.Tests;

public class ProductTests
{
    private Product product;
    private string label = "FirstProduct";
    private decimal price = 5.50m;
    private int quantity = 10;

    [SetUp]
    public void SetUp()
    {
        product = new Product(label, price, quantity);
    }

    [Test]
    public void ConstructorShouldWorkCorrecly()
    {
        Assert.That(product, Is.Not.Null);
        Assert.IsInstanceOf<IProduct>(product);
    }

    [Test]
    public void LaberPropertyShouldReturnCorrectValue()
    {
        Assert.AreEqual(label, product.Label);
    }

    [Test]
    public void PricePropertyShouldReturnCorrectValue()
    {
        Assert.AreEqual(price, product.Price);
    }

    [Test]
    public void QuantityPropertyShouldReturnCorrectValue()
    {
        Assert.AreEqual(quantity, product.Quantity);
    }

    [Test]
    public void CompareToMethodShouldCompareFirstByPrice()
    {
        IProduct product2 = new Product("SecondProduct", 7.50m, 20);

        int ExpectedResult = -1;

        Assert.AreEqual(ExpectedResult, product.CompareTo(product2));
    }

    [Test]
    public void CompareToMethodShouldCompareSecondByQuantity()
    {
        IProduct product2 = new Product("SecondProduct", 5.50m, 5);

        int ExpectedResult = 1;

        Assert.AreEqual(ExpectedResult, product.CompareTo(product2));
    }

    [Test]
    public void CompareToMethodShouldCompareThirdByLabel()
    {
        IProduct product2 = new Product("SecondProduct", 5.50m, 10);

        int ExpectedResult = -1;

        Assert.AreEqual(ExpectedResult, product.CompareTo(product2));
    }

    [Test]
    public void CompareToMethodShouldReturn0IfProductsAreEqualByAllCriteria()
    {
        IProduct product2 = new Product("FirstProduct", 5.50m, 10);

        int ExpectedResult = 0;

        Assert.AreEqual(ExpectedResult, product.CompareTo(product2));
    }
}
