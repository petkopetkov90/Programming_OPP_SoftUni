using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    private string brand;
    private double budget;
    private List<string> contributors;

    public Campaign(string brand, double budget)
    {
        Brand = brand;
        Budget = budget;
        contributors = new List<string>();
    }

    public string Brand
    {
        get => brand
            ;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandIsrequired);
            }
            brand = value;
        }
    }

    public double Budget { get => budget; private set => budget = value; }

    public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();

    public void Gain(double amount)
    {
        Budget += amount;
    }

    public void Engage(IInfluencer influencer)
    {
        contributors.Add(influencer.Username);
        Budget -= influencer.CalculateCampaignPrice();
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
    }

}
