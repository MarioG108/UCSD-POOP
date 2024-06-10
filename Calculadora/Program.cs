

public class Program
{
    static void Main(string[] args)
    {


        while (true)
        {

            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------ Calculadora XLR8 ------");
            Console.WriteLine("Seleccione una operación:");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese su opción: ");
            Console.ResetColor();
            double opcion = Calculadora.GetNumericIntInput();

            Console.ForegroundColor = ConsoleColor.Green;
            if (opcion == 5)
            {
                Console.WriteLine("Apagando sistemas...");
                break;
            }

            Console.Write("Ingrese el primer número: ");
            Console.ResetColor();
            double num1 = Calculadora.GetNumericDobleInput();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ingrese el segundo número: ");
            Console.ResetColor();
            double num2 = Calculadora.GetNumericDobleInput();


            Console.ForegroundColor = ConsoleColor.Green;
            double resultado = 0;

            switch (opcion)
            {
                case 1:
                    resultado = Calculadora.GetSuma(num1, num2);
                    Console.WriteLine($"La suma de {num1} y {num2} es: " + resultado);
                    break;
                case 2:
                    resultado = Calculadora.GetResta(num1, num2);
                    Console.WriteLine($"La resta de {num1} y {num2} es: " + resultado);
                    break;
                case 3:
                    resultado = Calculadora.GetMultiplicacion(num1, num2);
                    Console.WriteLine($"La multiplicación de {num1} y {num2} es: " + resultado);
                    break;
                case 4:
                    resultado = Calculadora.GetDivision(num1, num2);
                    if (!double.IsNaN(resultado))
                    {
                        Console.WriteLine($"La división de {num1} y {num2} es: " + resultado);
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.ResetColor();

        }
    }
}
