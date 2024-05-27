internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("TODO:");
        WriteODD();
        WriteSquare();


        Console.ReadLine();
    }
    /// <summary>
    /// 1- GENERAR LA RAIZ CUADRADA DESDE EL NÚMERO 1 HASTA EL NÚMERO 20 E IMPRIMIRLO POR CONSOLA.

    /// </summary>
    public static void WriteSquare()
    {
        Console.WriteLine("TODO:");
        Console.WriteLine("1- GENERAR LA RAIZ CUADRADA DESDE EL NÚMERO 1 HASTA EL NÚMERO 20 E IMPRIMIRLO POR CONSOLA.");

        int maxValue = 20;
        for (int i = 0; i <= maxValue; i++)
        {
            Console.WriteLine($"La raiz cuadrada de {i} es {Math.Round(Math.Sqrt(i),3)}");    
        }
        Console.WriteLine("");

        Console.WriteLine("Fin de raiz");
        Console.WriteLine("");

    }
    /// <summary>
    ///1- GENERAR LOS NUMEROS PARES EN UN RANGO DESDE EL NÚMERO 1 HASTA EL NÚMERO 20.

    /// </summary>
    public static void WriteODD()
    {
        Console.WriteLine("TODO:");
        Console.WriteLine("1- GENERAR LOS NUMEROS PARES EN UN RANGO DESDE EL NÚMERO 1 HASTA EL NÚMERO 20.");


        Console.WriteLine("");
        Console.WriteLine("Contador de numeros par");
        Console.WriteLine("");

        int maxValue = 20;

        for (int i = 0; i <= maxValue; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("El numero {0} es un par.", i);
            }
        }
        Console.WriteLine("");
        Console.WriteLine("Fin de pares");
        Console.WriteLine("");

    }
}