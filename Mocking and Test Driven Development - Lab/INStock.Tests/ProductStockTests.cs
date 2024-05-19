using INStock.Models;
using INStock.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests;

public class ProductStockTests
{
    private IProductStock productStock;

    [SetUp]
    public void SetUp()
    {
        productStock = new ProductStock();
    }

    [Test]
    public void ConstructorShouldWorkCorrectly()
    {
        Assert.IsNotNull(productStock);
        Assert.IsInstanceOf<IProductStock>(productStock);
    }

    [Test]
    public void CountPropertyShouldReturnCorrectValue()
    {
        Assert.AreEqual(0, productStock.Count);
    }

    [Test]
    public void IndexerShouldReturnCorrectly()
    {
        IProduct product = new Product("product", 5.50m, 10);
        productStock.Add(product);

        Assert.AreEqual(product, productStock[0]);
    }

    [TestCase(5)]
    [TestCase(0)]
    [TestCase(-1)]
    public void IndexerShouldThrowAnExeptionWhenIndexNotExist(int indext)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { IProduct product = productStock[indext]; });

        Assert.That(() => productStock[indext], Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void AddMethodShouldAddCorrectly()
    {
        IProduct product = new Product("product", 5.50m, 10);
        productStock.Add(product);

        Assert.AreEqual(1, productStock.Count);
    }

    [Test]
    public void ContainsMethodShouldAddCorrectly()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 5.50m, 10);
        productStock.Add(product);

        Assert.AreEqual(true, productStock.Contains(product));
        Assert.AreEqual(false, productStock.Contains(product2));
    }

    [Test]
    public void RemoveMethodShouldRemoveCorrectly()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 5.50m, 10);
        productStock.Add(product);

        Assert.IsFalse(productStock.Remove(product2));
        Assert.IsTrue(productStock.Remove(product));
        Assert.AreEqual(0, productStock.Count);
    }

    [Test]
    public void FindMethodShouldReturnCorrectProduct()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 5.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);

        Assert.AreEqual(product, productStock.Find(0));
        Assert.AreEqual(product2, productStock.Find(1));
    }

    [Test]
    public void FindMethodShouldThrowAnExceptionIfProductNotExist()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { IProduct product = productStock.Find(0); });
    }

    [Test]
    public void FindByLabelMethodShouldReturnCorrectProduct()
    {
        IProduct product = new Product("product", 5.50m, 10);
        productStock.Add(product);

        Assert.AreEqual(product, productStock.FindByLabel("product"));
    }

    [Test]
    public void FindByLabelMethodShouldThrowAnExceptionIfProductNotExist()
    {
        Exception exception = Assert.Throws<ArgumentException>(() => productStock.FindByLabel("product"));

        Assert.AreEqual("Тhe product does not exist", exception.Message);
    }

    [Test]
    public void FindMostExpensiveMethodShouldReturnCorrectProduct()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 7.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);

        Assert.AreEqual(product2, productStock.FindMostExpensiveProduct());
    }

    [Test]
    public void FindMostExpensiveMethodShouldThrowAnExceptionWhenStockIsEmpty()
    {
        Exception exception = Assert.Throws<ArgumentException>(() => productStock.FindMostExpensiveProduct());

        Assert.AreEqual("There are not products in stock", exception.Message);
    }

    [Test]
    public void FindAllInrangeMethodShouldFindCorrectProducts()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 7.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);

        Assert.AreEqual(2, productStock.FindAllInrangeAll(5, 8).Count());
        Assert.AreEqual(1, productStock.FindAllInrangeAll(5, 6).Count());
    }

    [Test]
    public void FindAllInrangeMethodShouldThrowAnExceptionWhenStockIsEmpty()
    {
        Exception exception = Assert.Throws<ArgumentException>(() => productStock.FindAllInrangeAll(5, 8));

        Assert.AreEqual("Stock is empty", exception.Message);
    }

    [Test]
    public void FindAllByPriceMethodShouldFindCorrectProducts()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 7.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);

        Assert.AreEqual(1, productStock.FindAllByPrice(5.50).Count());
        Assert.AreEqual(product, productStock.FindAllByPrice(5.50).First());
    }

    [Test]
    public void FindAllByPriceMethodShouldThrowAnExceptionWhenStockIsEmpty()
    {
        Exception exception = Assert.Throws<ArgumentException>(() => productStock.FindAllByPrice(5.50));

        Assert.AreEqual("Stock is empty", exception.Message);
    }

    [Test]
    public void FindAllByQuantityMethodShouldFindCorrectProducts()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 7.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);

        Assert.AreEqual(2, productStock.FindAllByQuantity(10).Count());
    }

    [Test]
    public void FindAllByQuantityMethodShouldThrowAnExceptionWhenStockIsEmpty()
    {
        Exception exception = Assert.Throws<ArgumentException>(() => productStock.FindAllByPrice(5.50));

        Assert.AreEqual("Stock is empty", exception.Message);
    }

    [Test]
    public void GetEnumeratorMethodShouldBeEnumarator()
    {
        IProduct product = new Product("product", 5.50m, 10);
        IProduct product2 = new Product("product2", 7.50m, 10);
        IProduct product3 = new Product("product3", 7.50m, 10);
        productStock.Add(product);
        productStock.Add(product2);
        productStock.Add(product3);

        IEnumerable<IProduct> expected = new List<IProduct>() { product, product2 };
        IEnumerable<IProduct> result = productStock.Take(2).ToList();

        CollectionAssert.AreEqual(expected, result);
    }
}
