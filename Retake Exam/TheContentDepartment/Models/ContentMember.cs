using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class ContentMember : TeamMember
{
    private readonly List<string> allowedPaths = new List<string>() { "CSharp", "JavaScript", "Python", "Java" };

    public ContentMember(string name, string path)
        : base(name, path)
    {
    }

    public override string Path
    {
        get { return path; }
        protected set
        {
            if (!allowedPaths.Contains(value))
            {
                throw new ArgumentException(ExceptionMessages.PathIncorrect);
            }
            path = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
    }
}
