using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private IRepository<IResource> resources;
    private IRepository<ITeamMember> members;
    private readonly List<string> memberTypes;
    private readonly List<string> resourceTypes;

    public Controller()
    {
        resources = new ResourceRepository();
        members = new MemberRepository();
        memberTypes = new List<string>() { "TeamLead", "ContentMember" };
        resourceTypes = new List<string>() { "Exam", "Workshop", "Presentation" };
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource currentResource = resources.TakeOne(resourceName);

        if (currentResource.IsTested is false)
        {
            return string.Format(OutputMessages.ResourceNotTested, currentResource.Name);
        }

        string teamLeadMemberName = members.Models.First(m => m.GetType().Name.Equals("TeamLead")).Name;

        ITeamMember teamLeadMember = members.TakeOne(teamLeadMemberName);

        if (isApprovedByTeamLead is true)
        {
            currentResource.Approve();
            teamLeadMember.FinishTask(currentResource.Name);
            return string.Format(OutputMessages.ResourceApproved, teamLeadMember.Name, currentResource.Name);
        }
        else
        {
            currentResource.Test();
            return string.Format(OutputMessages.ResourceReturned, teamLeadMember.Name, currentResource.Name);
        }
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (!resourceTypes.Contains(resourceType))
        {
            return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
        }

        ITeamMember currentTeamMember = members.Models.Where(m => m.GetType().Name.Equals("ContentMember")).FirstOrDefault(m => m.Path.Equals(path));

        if (currentTeamMember is null)
        {
            return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
        }

        if (currentTeamMember.InProgress.Contains(resourceName))
        {
            return string.Format(OutputMessages.ResourceExists, resourceName);
        }

        IResource currentResource = null;

        if (resourceType.Equals(resourceTypes[0]))
        {
            currentResource = new Exam(resourceName, currentTeamMember.Name);
        }
        if (resourceType.Equals(resourceTypes[1]))
        {
            currentResource = new Workshop(resourceName, currentTeamMember.Name);
        }
        if (resourceType.Equals(resourceTypes[2]))
        {
            currentResource = new Presentation(resourceName, currentTeamMember.Name);
        }

        currentTeamMember.WorkOnTask(currentResource.Name);
        resources.Add(currentResource);
        return string.Format(OutputMessages.ResourceCreatedSuccessfully, currentResource.Creator, currentResource.GetType().Name, currentResource.Name);
    }

    public string DepartmentReport()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Finished Tasks:");

        foreach (IResource resource in resources.Models.Where(r => r.IsApproved is true))
        {
            stringBuilder.AppendLine($"--{resource.ToString()}");
        }

        stringBuilder.AppendLine("Team Report:");
        stringBuilder.AppendLine($"--{members.Models.First(m => m.GetType() == typeof(TeamLead)).ToString()}");

        foreach (ITeamMember member in members.Models)
        {
            if (member.GetType() != typeof(TeamLead))
            {
                stringBuilder.AppendLine(member.ToString());
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (!memberTypes.Contains(memberType))
        {
            return string.Format(OutputMessages.MemberTypeInvalid, memberType);
        }

        if (memberType.Equals(memberTypes[1]))
        {
            if (members.Models.Any(m => m.Path.Equals(path)))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }
        }

        if (members.Models.Any(m => m.Name.Equals(memberName)))
        {
            return string.Format(OutputMessages.MemberExists, memberName);
        }

        ITeamMember teamMember = null;

        if (memberType.Equals(memberTypes[0]))
        {
            teamMember = new TeamLead(memberName, path);
        }
        else
        {
            teamMember = new ContentMember(memberName, path);
        }

        members.Add(teamMember);
        return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
    }

    public string LogTesting(string memberName)
    {
        ITeamMember currentMember = members.TakeOne(memberName);

        if (currentMember is null)
        {
            return string.Format(OutputMessages.WrongMemberName);
        }

        List<IResource> currentResources = resources.Models.Where(r => r.IsTested is false).OrderBy(r => r.Priority).ToList();

        IResource currentResource = currentResources.FirstOrDefault(r => r.Creator.Equals(currentMember.Name));

        if (currentResource is null || currentResource.Creator != currentMember.Name)
        {
            return string.Format(OutputMessages.NoResourcesForMember, currentMember.Name);
        }


        string teamLeadMemberName = members.Models.First(m => m.GetType().Name.Equals("TeamLead")).Name;

        ITeamMember teamLeadMember = members.TakeOne(teamLeadMemberName);

        currentMember.FinishTask(currentResource.Name);
        teamLeadMember.WorkOnTask(currentResource.Name);
        currentResource.Test();

        return string.Format(OutputMessages.ResourceTested, currentResource.Name);
    }
}
