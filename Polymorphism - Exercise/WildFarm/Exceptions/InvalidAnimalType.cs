
using System.Runtime.Serialization;

namespace WildFarm.Exceptions;

public class InvalidAnimalType : Exception
{
    private const string message = "Invalid Animal Type!";

    public InvalidAnimalType() 
        : base(message)
    {
    }
}
