namespace PersonsInfo;

public class Person
{
    private const string FistNameExcepction = "First name cannot contain fewer than 3 symbols!";
    private const string LastNameException = "Last name cannot contain fewer than 3 symbols!";
    private const string AgeException = "Age cannot be zero or a negative integer!";
    private const string SalaryException = "Salary cannot be less than 650 leva!";

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get => firstName;
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(FistNameExcepction);
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get => lastName;
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(LastNameException);
            }
            lastName = value;
        }
    }
    public int Age
    {
        get => age;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(AgeException);
            }
            age = value;
        }
    }

    public decimal Salary
    {
        get => salary;
        private set
        {
            if (value < 650)
            {
                throw new ArgumentException(SalaryException);
            }
            salary = value;
        }
    }

    public void IncreaseSalary(decimal precentage)
    {
        if (Age < 30)
        {
            precentage /= 2;
        }

        Salary += Salary * precentage / 100;
    }

    public override string ToString() => $"{FirstName} {LastName} receives {Salary:f2} leva.";
}

