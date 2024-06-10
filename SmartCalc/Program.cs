using System;
class Program
{
    static void Main(string[] args)
    {
        CalculadoraInteligente calculadora = new CalculadoraInteligente();

        int num = 5;
        long factorial = calculadora.CalcularFactorial(num);
        Console.WriteLine($"El factorial de {num} es: {factorial}");

        string palabra = "oso";
        bool esPalindromo = calculadora.EsPalindromo(palabra);
        Console.WriteLine($"La palabra '{palabra}' {(esPalindromo ? "es" : "no es")} un palíndromo.");
         palabra = "osa";
         esPalindromo = calculadora.EsPalindromo(palabra);
        Console.WriteLine($"La palabra '{palabra}' {(esPalindromo ? "es" : "no es")} un palíndromo.");

        int numPrimo = 7;
        bool esPrimo = calculadora.EsPrimo(numPrimo);
        Console.WriteLine($"El número {numPrimo} {(esPrimo ? "es" : "no es")} primo.");
        numPrimo = 15;
        esPrimo = calculadora.EsPrimo(numPrimo);
        Console.WriteLine($"El número {numPrimo} {(esPrimo ? "es" : "no es")} primo.");

        double celsius = 25;
        double fahrenheit = calculadora.CelsiusAFahrenheit(celsius);
        Console.WriteLine($"{celsius}°C = {fahrenheit}°F");

        double[] numeros = { 10, 20, 30, 40, 50 };
        double promedio = calculadora.CalcularPromedio(numeros);
        Console.WriteLine($"El promedio de los números ingresados es: {promedio}");

        string cadena = "Hola mundo";
        string cadenaInvertida = calculadora.InvertirCadena(cadena);
        Console.WriteLine($"La cadena invertida es: {cadenaInvertida}");

        string texto = "¡Hola, mundo!";
        int caracteres = calculadora.ContarCaracteres(texto);
        Console.WriteLine($"La cantidad de caracteres (sin contar espacios) es: {caracteres}");
        Console.ReadLine();
    }
}

public class CalculadoraInteligente
{
    public long CalcularFactorial(int num)
    {
        if (1 >= num)
            return 1;
        else
            return num * CalcularFactorial(num - 1);
    }

    public bool EsPalindromo(string palabra)
    {
        palabra = palabra.ToLower();
        string alrevez = InvertirCadena(palabra);
        if (alrevez != palabra)
            return false;

        return true;
    }

    public bool EsPrimo(int num)
    {
        if (num <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    public double CelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double CalcularPromedio(double[] numeros)
    {
        double suma = 0;
        foreach (double num in numeros)
        {
            suma += num;
        }
        return suma / numeros.Length;
    }

    public string InvertirCadena(string cadena)
    {
        char[] caracteres = cadena.ToCharArray();
        Array.Reverse(caracteres);
        return new string(caracteres);
    }

    public int ContarCaracteres(string texto)
    {
        return texto.Replace(" ", "").Length;
    }
}
