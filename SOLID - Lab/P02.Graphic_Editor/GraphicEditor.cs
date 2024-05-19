using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private IShape shape;

        public GraphicEditor(IShape shape)
        {
            Shape = shape;
        }

        public IShape Shape
        {
            get { return shape; }
            private set { shape = value; }
        }

        public string DrawShape()
        {
            return Shape.Draw();
        }
    }
}
