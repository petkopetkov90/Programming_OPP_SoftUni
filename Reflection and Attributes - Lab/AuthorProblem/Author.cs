namespace AuthorProblem;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    private string name;

    public AuthorAttribute(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }
}
