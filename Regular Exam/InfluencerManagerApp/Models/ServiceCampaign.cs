using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    //can contribute to business and blogger influencers

    private const double InitialBudget = 30_000;

    public ServiceCampaign(string brand)
        : base(brand, InitialBudget)
    {
    }
}
