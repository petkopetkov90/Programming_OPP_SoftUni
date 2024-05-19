namespace Television.Tests;
using NUnit.Framework;
using System;
using Television;

public class Tests
{
    public const int defaultChannel = 0;
    public const int defaultVolume = 13;
    public const bool defaultMuted = false;
    private const string brand = "Samsung";
    private const double price = 500;
    private const int screenWidth = 100;
    private const int screenHeigth = 50;
    private TelevisionDevice devise;

    [SetUp]
    public void Setup()
    {
        devise = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
    }

    [Test]
    public void ConstructorShouldWorkCorrectly()
    {
        Assert.IsNotNull(devise);
        Assert.IsInstanceOf<TelevisionDevice>(devise);
        Assert.AreEqual(brand, devise.Brand);
        Assert.AreEqual(price, devise.Price);
        Assert.AreEqual(screenWidth, devise.ScreenWidth);
        Assert.AreEqual(screenHeigth, devise.ScreenHeigth);
    }

    [Test]
    public void BrandPropertyShouldSetAndGetCorrecly()
    {
        string newBrand = "Neo";
        devise.Brand = newBrand;
        Assert.AreEqual(newBrand, devise.Brand);
    }

    [Test]
    public void PricePropertyShouldSetAndGetCorrecly()
    {
        double newPrice = 120.50;
        devise.Price = newPrice;
        Assert.AreEqual(newPrice, devise.Price);
    }

    [Test]
    public void SreenWidthPropertyShouldSetAndGetCorrecly()
    {
        int newSreenWidth = 60;
        devise.ScreenWidth = newSreenWidth;
        Assert.AreEqual(newSreenWidth, devise.ScreenWidth);
    }

    [Test]
    public void ScreenHeigthPropertyShouldSetAndGetCorrecly()
    {
        int newScreenHeigth = 30;
        devise.ScreenHeigth = newScreenHeigth;
        Assert.AreEqual(newScreenHeigth, devise.ScreenHeigth);
    }

    [Test]
    public void CurrentChannelPropertyShouldReturnLastChanelOrDefault_0()
    {
        Assert.AreEqual(defaultChannel, devise.CurrentChannel);
    }

    [Test]
    public void VolumePropertyShouldReturnLastChanelOrDefault_13()
    {
        Assert.AreEqual(defaultVolume, devise.Volume);
    }

    [Test]
    public void IsMutedShouldReturnLastChanelOrDefault_False()
    {
        Assert.AreEqual(defaultMuted, devise.IsMuted);
    }

    [Test]
    public void SwitchOnMethodShouldReturnLastChanelOrDefault_False()
    {

        string defaultSound = defaultMuted ? "Off" : "On";

        Assert.AreEqual($"Cahnnel {defaultChannel} - Volume {defaultVolume} - Sound {defaultSound}", devise.SwitchOn());
    }

    [TestCase(0)]
    [TestCase(15)]
    public void ChangeChannelMethodShouldSetChannelCorrectly(int channel)
    {


        Assert.AreEqual(channel, devise.ChangeChannel(channel));
        Assert.AreEqual(channel, devise.CurrentChannel);
    }

    [TestCase(-1)]
    [TestCase(-23)]
    public void ChangeChannelMethodShouldThrowAnExceptionIfChannelIsNegative(int channel)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => devise.ChangeChannel(channel));

        Assert.AreEqual("Invalid key!", exception.Message);
    }

    [TestCase("UP", 5)]
    [TestCase("UP", 50)]
    [TestCase("UP", 99)]
    [TestCase("DOWN", 50)]
    [TestCase("DOWN", 13)]
    [TestCase("DOWN", 0)]
    public void VolumeChangeMethodShouldChangeVolumeCorrectly(string direction, int units)
    {
        int expectedVolume = defaultVolume;

        if (direction == "UP")
        {
            expectedVolume += units;
            if (expectedVolume > 100)
            {
                expectedVolume = 100;
            }
        }
        if (direction == "DOWN")
        {
            expectedVolume -= units;
            if (expectedVolume < 0)
            {
                expectedVolume = 0;
            }
        }

        Assert.That(devise.VolumeChange(direction, units).Equals($"Volume: {expectedVolume}"));
        Assert.AreEqual(expectedVolume, devise.Volume);
    }

    [Test]
    public void MuteDeviceMethodShouldMuteOnOffCorrely()
    {
        Assert.AreEqual(true, devise.MuteDevice());
        Assert.AreEqual(true, devise.IsMuted);
    }


    [Test]
    public void ToStringMethodShouldRetunrCorrectString()
    {
        Assert.That(devise.ToString().Equals($"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$"));
    }


}