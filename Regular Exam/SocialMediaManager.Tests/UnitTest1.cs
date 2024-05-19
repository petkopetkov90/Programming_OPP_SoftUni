using System.Linq;
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace SocialMediaManager.Tests;

public class Tests
{
    private InfluencerRepository influencerRepository;
    private Influencer influencer;

    [SetUp]
    public void Setup()
    {
        influencerRepository = new InfluencerRepository();
        influencer = new Influencer("Petko", 2);
    }

    [Test]
    public void ConstructorShouldWorkCorrectly()
    {
        Assert.IsNotNull(influencerRepository);
        Assert.IsInstanceOf<InfluencerRepository>(influencerRepository);
        Assert.IsNotNull(influencerRepository.Influencers);
    }

    [Test]
    public void RegisterInfluencerShouldRegisterCorrectly()
    {
        Assert.That(influencerRepository.RegisterInfluencer(influencer).Equals($"Successfully added influencer {influencer.Username} with {influencer.Followers}"));
        Assert.AreEqual(1, influencerRepository.Influencers.Count());
    }

    [Test]
    public void RegisterInfluencerShouldThrowAnExceptionWhenIsNull()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => influencerRepository.RegisterInfluencer(null));

        Assert.AreEqual(0, influencerRepository.Influencers.Count);
        Assert.AreEqual("Influencer is null (Parameter 'influencer')", exception.Message);
    }

    [Test]
    public void RegisterInfluencerShouldThrowAnExceptionIfIsAlreadyRegistered()
    {
        influencerRepository.RegisterInfluencer(influencer);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => influencerRepository.RegisterInfluencer(influencer));

        Assert.AreEqual(1, influencerRepository.Influencers.Count);
        Assert.AreEqual($"Influencer with username {influencer.Username} already exists", exception.Message);
    }

    [Test]
    public void RemoveInfluencerShouldRemoveCorrectly()
    {
        Assert.IsFalse(influencerRepository.RemoveInfluencer(influencer.Username));

        influencerRepository.RegisterInfluencer(influencer);

        Assert.IsTrue(influencerRepository.RemoveInfluencer(influencer.Username));
        Assert.AreEqual(0, influencerRepository.Influencers.Count);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("      ")]
    public void RemoveInfluencerShouldThrowAnExceptionWhenNameIsNullOrWhiteSpace(string name)
    {
        influencerRepository.RegisterInfluencer(influencer);

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(name));

        Assert.AreEqual($"Username cannot be null (Parameter 'username')", exception.Message);
        Assert.AreEqual(1, influencerRepository.Influencers.Count());
    }

    [Test]
    public void GetInfluencerWithMostFollowersShouldReturnCorrectly()
    {

        influencerRepository.RegisterInfluencer(influencer);
        influencerRepository.RegisterInfluencer(new Influencer("Gosho", 1));

        Assert.AreEqual(influencer, influencerRepository.GetInfluencerWithMostFollowers());
    }

    [Test]
    public void GetInfluencerShouldReturnCorrectly()
    {

        influencerRepository.RegisterInfluencer(influencer);
        influencerRepository.RegisterInfluencer(new Influencer("Gosho", 1));

        Assert.AreEqual(influencer, influencerRepository.GetInfluencer(influencer.Username));
    }

}