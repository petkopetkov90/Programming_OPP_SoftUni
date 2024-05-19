
using Shapes.Core.Interfaces;
using Shapes.IO.Interfaces;
using Shapes.Models;
using System.Drawing;

namespace Shapes.Core;

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

    }
}
