using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class Resource : IResource
{
    private string name;
    private string creator;
    private int priority;
    private bool isTested;
    private bool isApproved; 

    protected Resource(string name, string creator, int priority)
    {
        Name = name;
        Creator = creator;
        Priority = priority;
        IsTested = false;
        IsApproved = false;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
            }
            name = value;
        }
    }

    public string Creator
    {
        get { return creator; }
        private set { creator = value; }
    }

    public int Priority
    {
        get { return priority; }
        private set { priority = value; }
    }

    public bool IsTested
    {
        get { return isTested; }
        private set { isTested = value; }
    }

    public bool IsApproved
    {
        get { return isApproved; }
        private set { isApproved = value; }
    }

    public void Approve()
    {
        IsApproved = true;
    }

    public void Test()
    {
        IsTested = !IsTested;
    }

    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}), Created By: {Creator}";
    }
}
