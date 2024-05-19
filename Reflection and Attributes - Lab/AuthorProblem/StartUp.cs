namespace AuthorProblem;

[Author("Victor")]
public class StartUp
{
    [Author("George")]
    static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}