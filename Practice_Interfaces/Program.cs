using Practice_Interfaces.Classes;
using Practice_Interfaces.Interfaces;
using System.Reflection.Metadata;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Operaciones disponibles:");
        Console.WriteLine((int)Operaciones.Sumar + " - " + Operaciones.Sumar);
        Console.WriteLine((int)Operaciones.Restar + " - " + Operaciones.Restar);
        Console.WriteLine((int)Operaciones.Multiplicar + " - " + Operaciones.Multiplicar);
        Console.WriteLine((int)Operaciones.Dividir + " - " + Operaciones.Dividir);
        //Solicita al usuario que elija una opcion y la almacena en una variable
        Console.WriteLine("Elija el numero de la operacion a realizar:");
        int operacion = (int)GetNumericIntInput();
        //Solicita al usuario que ingrese el primer numero a calcular y la almacena en una variable
        Console.WriteLine("Escribe un primer numero: ");
        decimal entrada1 = GetNumericIntInput();
        //Solicita al usuario que ingrese el segundo numero a calcular y la almacena en una variable
        Console.WriteLine("Escribe un segundo numero: ");
        decimal entrada2 = GetNumericIntInput();

        //Instanciamos la clase Calculadora y le pasamos los parametros del usuario
        Calculadora calc = new(entrada1, entrada1);

        //comparamos la operación elegida por el usuario y los casos disponibles:
        switch (operacion)
        {
            case (int)Operaciones.Sumar:
                Console.WriteLine($"La suma de {entrada1} y {entrada2} es: " + calc.GetSuma());
                Console.Read();
                break;
            case (int)Operaciones.Restar:
                Console.WriteLine($"La resta de {entrada1} y {entrada2} es: " + calc.GetResta());
                Console.Read();

                break;
            case (int)Operaciones.Multiplicar:
                Console.WriteLine($"La multiplicacion de {entrada1} y {entrada2} es: " + calc.GetMultiplicacion());
                Console.Read();

                break;
            case (int)Operaciones.Dividir:
                Console.WriteLine($"La division de {entrada1} y {entrada2} es: " + calc.GetDivision());
                Console.Read();

                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La opción elegida no es valida");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("0 - Reintentar");
                if ((int)GetNumericIntInput() == 0)
                {
                    Console.Clear();
                    Main(args);
                }                
                break;
        }

    }
    private static decimal GetNumericIntInput()
    {

        decimal input;
        while (!decimal.TryParse(Console.ReadLine(), out input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por favor, ingrese un valor numérico válido.");
            Console.ResetColor();
        }
        return input;
    }

}