List<Shape> shapes = new List<Shape>();

shapes.Add(new Square("Blue", 5));
shapes.Add(new Rectangle("Green", 4, 5));
shapes.Add(new Circle("Red", 3));

foreach (Shape shape in shapes)
{
    Console.WriteLine(shape.GetColor());
    Console.WriteLine(shape.GetArea());
}