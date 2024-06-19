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
        
        Console.WriteLine("Elija el numero de la operacion a realizar:");
        int operacion = int.Parse(Console.ReadLine());
        Console.WriteLine("Escribe un primer numero: ");
        decimal entrada1 = Decimal.Parse(Console.ReadLine());
        Console.WriteLine("Escribe un segundo numero: ");
        decimal entrada2 = Decimal.Parse(Console.ReadLine());
        Calculadora calc = new(entrada1, entrada1);

        switch (operacion)
        {
            case (int)Operaciones.Sumar:
                Console.WriteLine($"La suma de {entrada1} y {entrada2} es: "+ calc.GetSuma());
                break;
            case (int)Operaciones.Restar:
                Console.WriteLine($"La resta de {entrada1} y {entrada2} es: " + calc.GetResta());

                break;
            case (int)Operaciones.Multiplicar:
                Console.WriteLine($"La multiplicacion de {entrada1} y {entrada2} es: " + calc.GetMultiplicacion());
                break;
            case (int)Operaciones.Dividir:
                Console.WriteLine($"La division de {entrada1} y {entrada2} es: " +  calc.GetDivision());
                break;
        }

        Console.Read();
    }

}