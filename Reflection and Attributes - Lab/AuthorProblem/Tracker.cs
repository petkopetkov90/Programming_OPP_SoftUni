using System.Reflection;
using System.Text;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        MethodInfo[] methods = typeof(StartUp).GetMethods((BindingFlags)60);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (MethodInfo method in methods.Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute))))
        {
            var attributes = method.GetCustomAttributes(false);
            foreach (AuthorAttribute attribute in attributes)
            {
                stringBuilder.AppendLine($"{method.Name} is written by {attribute.Name}");
            }
        }

        Console.WriteLine(stringBuilder.ToString().TrimEnd());
    }
}
