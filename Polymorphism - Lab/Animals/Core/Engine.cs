
using Animals.Core.Interfaces;
using Animals.IO.Interfaces;
using Animals.Models;

namespace Animals.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Start()
    {
        Animal cat = new Cat("Peter", "Whiskas");
        Animal dog = new Dog("George", "Meat");

        writer.WriteLine(cat.ExplainSelf());
        writer.WriteLine(dog.ExplainSelf());
    }
}
