using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese la cantidad de números de la secuencia Fibonacci que desea generar:");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Secuencia Fibonacci:");
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }

        Console.WriteLine("");
        Console.WriteLine("Precione una tecla para cerrar");
        Console.ReadKey();
    }

    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}