using EFCoreFinalProject.Interfaces;

namespace EFCoreFinalProject.Implementations;

public class GetValueService : IGetValueService
{
    public string GetStringInputValue()
    {
        string value;
        do
        {
            value = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(value));

        return value;
    }

    public int GetIntInputValue()
    {
        if(!int.TryParse(Console.ReadLine(), out int num))
            throw new Exception("Invalid input");

        return num;
    }

    public decimal GetDecimalInputValue()
    {
        if(!decimal.TryParse(Console.ReadLine(), out decimal num))
            throw new Exception("Invalid input");

        return num;
    }
}