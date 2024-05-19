using System;
using ValidationAttributes.Models;
using ValidationAttributes.Utilities;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person
             (
                 fullName: null,
                 age: -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
