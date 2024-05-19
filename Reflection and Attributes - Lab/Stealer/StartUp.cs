
using System;

namespace Stealer;

public class StartUp
{
    static void Main()
    {
        Spy spy = new Spy();

        //string output = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

        //string output = spy.AnalyzeAccessModifiers("Stealer.Hacker");

        //string output = spy.RevealPrivateMethods("Stealer.Hacker");

        string output = spy.CollectGettersAndSetters("Stealer.Hacker");

        Console.WriteLine(output);
    }
}