using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{
    private readonly string allowedPath = "Master";

    public TeamLead(string name, string path)
        : base(name, path)
    {
    }

    public override string Path
    {
        get { return path; }
        protected set
        {
            if (value != allowedPath)
            {
                throw new ArgumentException(ExceptionMessages.PathIncorrect, value);
            }
            path = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}) - Currently working on {InProgress.Count} tasks.";
    }
}
