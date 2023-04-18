
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

double MemoryValue = 0 ;
double ActionCount = 0;
Console.WriteLine("Вы можете \n" +
    "Прибавлять                                    введя +  \n" +
    "Отнимать                                      введя -\n" +
    "Умножать                                      введя *\n" +
    "Делить                                        введя /\n" +
    "Использовать число в последнее число в памяти введя M\n" +
    "Очистить память                               введя CM\n" +
    "Для остановки программы                       введите Stop или Exit\n");

while (true)
{

    double ValueOne=IntEnter(ref MemoryValue,ref ActionCount);
    int action = CheckTryAction();
    double ValueTwo = IntEnter(ref MemoryValue,ref ActionCount);
    double Result = CheckAction(ValueOne, ValueTwo, action);
    MemoryValue = Result;
    Console.WriteLine(Result);
    ActionCount++;
    CheckAction(ValueOne, ValueTwo, action);

    Console.WriteLine();
}

dynamic CheckAction(double valueOne,double valueTwo ,int action)
{

    if (action == 1) return valueOne + valueTwo;
    else if (action == 2) return valueOne - valueTwo;
    else if (action == 3) return valueOne * valueTwo;
    else
    {
        if (valueTwo == 0)
        {
            Console.WriteLine("На ноль делить нельзя измените число или выйдите");
            return CheckAction(valueOne,IntEnter(ref MemoryValue,ref ActionCount),action);
        }
        else return valueOne / valueTwo; 
    }
}

dynamic CheckTryAction()
{
    string action = Console.ReadLine();
    if (action == "+") return 1;
    else if (action == "-") return 2;
    else if (action == "*") return 3;
    else if (action == "/") return 4;
    else if (action == "Exit" || action == "Stop" || action == "exit" || action == "stop")
    {
        Console.WriteLine("Goodbye");
        Environment.Exit(0);
        return false;
    }
    else
    { 
        Console.WriteLine("TryAgain");
        return CheckTryAction(); 
    }

}

dynamic IntEnter(ref double MemoryValue,ref double ActionCount)
{
    double Symbol = 1;
    string EnterNum = Console.ReadLine();
    if (Convert.ToString(EnterNum[0]) == "-")
        Symbol = -1;
    try
    {
        double Result = double.Parse(EnterNum) * Symbol;
        Result *= Symbol;
        return Result;
    }
    catch
    {
        if (EnterNum == "Exit" || EnterNum == "Stop" || EnterNum == "exit" || EnterNum == "stop")
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            return false;
        }
        else if (EnterNum=="CM" || EnterNum=="cm")
        {
            Console.WriteLine("Вы очистили память");
            ActionCount= 0;
            MemoryValue = 0;
            return IntEnter(ref MemoryValue, ref ActionCount);
        }
        else if (EnterNum=="M"|| EnterNum=="m")
        {
            if (MemoryValue == 0 & ActionCount == 0)
            {
                Console.WriteLine("Вы еще не совершали операций или память пуста, введите число или выйдите");
                return IntEnter(ref MemoryValue, ref ActionCount);
            }
            else
            {
                MemoryValue *= Symbol;
                return MemoryValue;
            }
        }
        else
        {
            Console.WriteLine("Try Again");
            return IntEnter(ref MemoryValue,ref ActionCount);
        }

    }
    

}

