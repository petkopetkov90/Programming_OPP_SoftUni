
string[] bankAccounts = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

Dictionary<int, decimal> acoountsBalance = new Dictionary<int, decimal>();

for (int i = 0; i < bankAccounts.Length; i++)
{
    string[] currentAccount = bankAccounts[i].Split("-");

    acoountsBalance.Add(int.Parse(currentAccount[0]), decimal.Parse(currentAccount[1]));
}

string commandInfo;

while ((commandInfo = Console.ReadLine()) != "End")
{
    string[] commandDetails = commandInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string commandType = commandDetails[0];
    int accountNumber = int.Parse(commandDetails[1]);
    decimal sum = decimal.Parse(commandDetails[2]);

    try
    {
        if (commandType == "Deposit")
        {
            if (!acoountsBalance.ContainsKey(accountNumber))
            {
                throw new ArgumentException("Invalid account!");
            }

            acoountsBalance[accountNumber] += sum;
        }
        else if (commandType == "Withdraw")
        {
            if (acoountsBalance[accountNumber] < sum)
            {
                throw new ArgumentException("Insufficient balance!");
            }

            acoountsBalance[accountNumber] -= sum;
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {acoountsBalance[accountNumber]:f2}");
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine(exception.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}