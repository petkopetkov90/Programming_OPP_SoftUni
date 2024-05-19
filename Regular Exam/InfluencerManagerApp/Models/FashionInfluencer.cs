using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public class FashionInfluencer : Influencer
{
    //can contribute to product campaigns

    private const double InitialEngagementRate = 4.0;
    private const double Factor = 0.1;

    public FashionInfluencer(string username, int followers)
        : base(username, followers, InitialEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)(Followers * EngagementRate * Factor);  //Away from zero or not?
    }
}
