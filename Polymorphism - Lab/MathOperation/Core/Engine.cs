
using Operations.Core.Interfaces;
using Operations.IO.Interfaces;
using Operations.Models;

namespace Operations.Core;

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
        MathOperations mo = new MathOperations();
        writer.WriteLine(mo.Add(2, 3));
        writer.WriteLine(mo.Add(2.2, 3.3, 5.5));
        writer.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
    }
}
