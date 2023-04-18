
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

while (true)
{

    double ValueOne=IntEnter();
    int action = CheckTryAction();
    double ValueTwo = IntEnter();


    Console.WriteLine(CheckAction(ValueOne, ValueTwo, action));
    




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
            return CheckAction(valueOne,IntEnter(),action);
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

dynamic IntEnter()
{
    string EnterNum = Console.ReadLine();
    try
    {
        return double.Parse(EnterNum);
    }
    catch
    {
        if (EnterNum == "Exit" || EnterNum == "Stop" || EnterNum == "exit" || EnterNum == "stop")
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            return false;
        }
        else
        {
            Console.WriteLine("Try Again");
            return IntEnter();
        }

    }

}

