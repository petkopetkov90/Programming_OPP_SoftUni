using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public class BusinessInfluencer : Influencer
{
    //can contribute in all campaigns

    private const double InitialEngagementRate = 3.0;
    private const double Factor = 0.15;

    public BusinessInfluencer(string username, int followers) 
        : base(username, followers, InitialEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)(Followers * EngagementRate * Factor);  //Away from zero or not?
    }
}
