using TemplatePattern.Models;

namespace TemplatePattern;

public class StartUp
{
    static void Main()
    {
        Sourdough sourdoughBread = new Sourdough();
        TwelveGrain twelveGrainBread = new TwelveGrain();
        WholeWheat wholeWheatBread = new WholeWheat();

        sourdoughBread.Make();
        twelveGrainBread.Make();
        wholeWheatBread.Make();
    }
}
