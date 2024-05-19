using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private IRepository<IInfluencer> influencers;
    private IRepository<ICampaign> campaigns;
    private readonly HashSet<string> influencerTypes;
    private readonly HashSet<string> campaignTypes;

    public Controller()
    {
        influencers = new InfluencerRepository();
        campaigns = new CampaignRepository();
        influencerTypes = new HashSet<string>() { "BusinessInfluencer", "FashionInfluencer", "BloggerInfluencer" };
        campaignTypes = new HashSet<string>() { "ProductCampaign", "ServiceCampaign" };
    }

    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        if (!influencerTypes.Contains(typeName))
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }

        if (influencers.Models.Any(i => i.Username == username))
        {
            return string.Format(OutputMessages.UsernameIsRegistered, username, influencers.GetType().Name);
        }

        IInfluencer currentInfluencer = null;

        if (typeName == "BusinessInfluencer")
        {
            currentInfluencer = new BusinessInfluencer(username, followers);
        }
        else if (typeName == "FashionInfluencer")
        {
            currentInfluencer = new FashionInfluencer(username, followers);
        }
        else if (typeName == "BloggerInfluencer")
        {
            currentInfluencer = new BloggerInfluencer(username, followers);
        }

        influencers.AddModel(currentInfluencer);
        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        if (!campaignTypes.Contains(typeName))
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        if (campaigns.Models.Any(i => i.Brand == brand))
        {
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }

        ICampaign currentCampaign = null;

        if (typeName == "ProductCampaign")
        {
            currentCampaign = new ProductCampaign(brand);
        }
        else if (typeName == "ServiceCampaign")
        {
            currentCampaign = new ServiceCampaign(brand);
        }

        campaigns.AddModel(currentCampaign);
        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, currentCampaign.GetType().Name);
    }

    public string AttractInfluencer(string brand, string username)
    {
        IInfluencer currentInfluencer = influencers.FindByName(username);
        ICampaign currentCampaign = campaigns.FindByName(brand);

        if (currentInfluencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);
        }

        if (currentCampaign is null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        if (currentCampaign.Contributors.Contains(currentInfluencer.Username))
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
        }

        string campaignType = currentCampaign.GetType().Name;
        string influencerType = currentInfluencer.GetType().Name;

        if (!influencerType.Equals("BusinessInfluencer"))
        {
            if ((campaignType.Equals("ProductCampaign") && influencerType.Equals("BloggerInfluencer"))
                || (campaignType.Equals("ServiceCampaign") && influencerType.Equals("FashionInfluencer")))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }
        }

        if (currentCampaign.Budget < currentInfluencer.CalculateCampaignPrice())
        {
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);
        }

        currentInfluencer.EnrollCampaign(currentCampaign.Brand);
        currentCampaign.Engage(currentInfluencer);
        currentInfluencer.EarnFee(currentInfluencer.CalculateCampaignPrice());
        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
    }

    public string FundCampaign(string brand, double amount)
    {
        ICampaign currentCampaign = campaigns.FindByName(brand);

        if (currentCampaign is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToFund);
        }

        if (amount <= 0)
        {
            return string.Format(OutputMessages.NotPositiveFundingAmount);
        }

        currentCampaign.Gain(amount);
        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
    }

    public string CloseCampaign(string brand)
    {
        ICampaign currentCampaign = campaigns.FindByName(brand);

        if (currentCampaign is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToClose);
        }

        if (currentCampaign.Budget <= 10_000)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
        }

        IInfluencer currentInfluencer;
        double bonus = 2_000;

        foreach (var influencerName in currentCampaign.Contributors)
        {
            currentInfluencer = influencers.FindByName(influencerName);
            currentInfluencer.EarnFee(bonus);
            currentInfluencer.EndParticipation(currentCampaign.Brand);
        }

        campaigns.RemoveModel(currentCampaign);
        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
    }

    public string ConcludeAppContract(string username)
    {
        IInfluencer currentInfluencer = influencers.FindByName(username);

        if (currentInfluencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }

        if (currentInfluencer.Participations.Count > 0)
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
        }

        influencers.RemoveModel(currentInfluencer);
        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
    }

    public string ApplicationReport()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (IInfluencer influencer in influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers))
        {
            stringBuilder.AppendLine(influencer.ToString());

            if(influencer.Participations.Count > 0)
            {
                stringBuilder.AppendLine("Active Campaigns:");

                ICampaign currentCampaign;

                foreach (string campaign in influencer.Participations)
                {
                    currentCampaign = campaigns.FindByName(campaign);

                    stringBuilder.AppendLine($"--{currentCampaign.ToString()}");
                }
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
