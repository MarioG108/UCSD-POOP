public static class Calculadora
{

    public static double GetDivision(double num1, double num2)
    {
        if (num2 == 0)
        {
            Console.WriteLine("No se puede dividir por cero.");
            return double.NaN; // Not a Number
        }
        else
        {
            return num1 / num2;
        }
    }

    public static double GetMultiplicacion(double num1, double num2)
    {
        return num1 * num2;
    }
    public static double GetNumericDobleInput()
    {
        double input;
        while (!double.TryParse(Console.ReadLine(), out input))
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Por favor, ingrese un valor numérico válido.");
            Console.ResetColor();
        }
        return input;
    }

    public static int GetNumericIntInput()
    {

        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por favor, ingrese un valor numérico válido.");
            Console.ResetColor();
        }
        return input;
    }

    public static double GetResta(double num1, double num2)
    {
        return num1 - num2;
    }
    public static double GetSuma(double num1, double num2)
    {
        return num1 + num2;
    }
}