using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public class BloggerInfluencer : Influencer
{
    //can contribute to service campaigns

    private const double InitialEngagementRate = 2.0;
    private const double Factor = 0.2;

    public BloggerInfluencer(string username, int followers)
        : base(username, followers, InitialEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)(Followers * EngagementRate * Factor);  //Away from zero or not?
    }
}
