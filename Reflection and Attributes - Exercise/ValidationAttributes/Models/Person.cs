﻿using ValidationAttributes.Attributes;
using ValidationAttributes.Models.Interfaces;

namespace ValidationAttributes.Models
{
    public class Person : IPerson
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(12, 90)]
        public int Age { get; private set; }
    }
}
