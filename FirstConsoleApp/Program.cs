using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        bool validator = true;
        int firstNumber, secondNumber;
        while (validator)
        {

            Console.WriteLine("Ingrese un numero:");
            int.TryParse(Console.ReadLine(), out firstNumber);
            
            Console.WriteLine("Ingrese otro numero:");

            int.TryParse(Console.ReadLine(), out secondNumber);
            
            
            Console.WriteLine("...procesando...");
            Sum(firstNumber, secondNumber);
            Console.WriteLine();
            Console.WriteLine("===================");
            Console.WriteLine("escriba 'Exit' para salir.");
            if (Console.ReadLine().ToLower() == "exit")
            {
                validator = false;
            }
            Console.WriteLine("===================");
        }


    }
    
    static void Sum(int firstNumber, int secondNumber)
    {
        Console.WriteLine($"la suma es: {firstNumber + secondNumber}");
    }
}