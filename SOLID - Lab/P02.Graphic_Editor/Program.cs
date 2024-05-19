using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor(new Rectangle());
            Console.WriteLine(graphicEditor.DrawShape());
        }
    }
}
