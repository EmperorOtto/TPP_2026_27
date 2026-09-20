using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите начальный баланс: ");
        int balance = Convert.ToInt32(Console.ReadLine());
        int input = 0;
        List<string> operations = new List<string>();

        while (input != 5)
        {
            Console.WriteLine("1. Показать баланс\n2. Пополнить счёт\n3. Снять деньги\n4. Показать историю операций\n5. Выйти");
            Console.Write("Выберите действие: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                PrintBalance(balance, "$");
            }
            else if (input == 2)
            {
                TopUpBalance(ref balance, operations);
            }
            else if (input == 3)
            {
                balance = WithdrawMoney(balance, operations);
            }
            else if (input == 4)
            {
                PrintTransHistory(operations);
            }
        }
    }

    public static void PrintBalance(int balance, string currency = "₽")
    {
        Console.WriteLine($"\nТекущий баланс: {balance} {currency}\n");
    }
    public static void TopUpBalance(ref int balance, List<string> operations)
    {
        Console.Write("\nВведите сумму пополнения: ");
        int ammount = Convert.ToInt32(Console.ReadLine());

        if (ammount > 0)
        {
            balance += ammount;
            operations.Add($"Пополнение баланса на {ammount}");
            Console.WriteLine($"Баланс пополнен на {ammount}\n");
        }
        else
        {
            Console.WriteLine("Сумма пополнения введена некорректно!\n");
        }
    }
    public static int WithdrawMoney(int balance, List<string> operations)
    {
        Console.Write("\nВведите сумму снятия: ");
        int ammount = Convert.ToInt32(Console.ReadLine());

        if (ammount <= 0)
        {
            Console.WriteLine("Сумма снятия введена некорректно!\n");
        }
        else if (ammount > balance)
        {
            Console.WriteLine("На счёте недостаточно средств!\n");
        }
        else
        {
            balance -= ammount;
            operations.Add($"Снятие суммы {ammount} с баланса");
            Console.WriteLine("Сумма успешно снята с баланса.\n");
        }
        return balance;
    }

    public static void PrintTransHistory(List<string> operations)
    {
        Console.WriteLine("\n- История Ваших операций -");
        if (operations.Count == 0)
        {
            Console.WriteLine("Вы пока не совершали никаких операций\n");
            return;
        }
        for (int i = 0; i < operations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {operations[i]}");
        }
        Console.WriteLine();
    }
} 
