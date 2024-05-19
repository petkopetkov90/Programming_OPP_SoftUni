using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    private object newInstance;
    private FieldInfo[] fields;
    private MethodInfo[] methods;

    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        StringBuilder stringBuilder = new StringBuilder();

        Type classType = Type.GetType(className);
        newInstance = classType.Assembly.CreateInstance(className);

        stringBuilder.AppendLine($"Class under investigation: {classType.FullName}");

        fields = classType.GetFields((BindingFlags)60);

        foreach (FieldInfo field in fields.Where(f => fieldsNames.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(newInstance)}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        StringBuilder stringBuilder = new StringBuilder();

        fields = Type.GetType(className).GetFields((BindingFlags)60);

        foreach (FieldInfo field in fields.Where(f => f.IsPublic))
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        methods = Type.GetType(className).GetMethods((BindingFlags)60);

        foreach (var method in methods.Where(m => m.IsPrivate && m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in methods.Where(m => m.IsPublic && m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"All Private Methods of Class: {className}");
        stringBuilder.AppendLine($"Base Class: {Type.GetType(className).BaseType.Name}");

        methods = Type.GetType(className).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (MethodInfo method in methods.Where(m => m.IsPrivate))
        {
            stringBuilder.AppendLine($"{method.Name}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        methods = Type.GetType(className).GetMethods((BindingFlags)60);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnParameter}");
        }

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
