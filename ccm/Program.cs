using System.Text.Json;
using System.Text.RegularExpressions;

///Carla
///Christopher
///Mario
namespace FormularioCCM
{
    public enum Genero
    {
        Omitido = 1,
        Masculino = 2,
        Femenino = 3
    }
    public enum Servicio
    {
        Básico = 1,
        Plus = 2,
        Premium = 3
    }
    public class Reclamacion
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public Genero Genero { get; set; }
        public string NumeroTelefonico { get; set; }

        public Servicio Servicio { get; set; }
        public string Comentarios { get; set; }

        public override string ToString()
        {
            return String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Genero, NumeroTelefonico, Servicio, Comentarios);
        }
        public string ToJson()
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<Reclamacion>(this, options);
        }


        public static Reclamacion FromString(string data)
        {
            var parts = data.Split('|');
            return new Reclamacion
            {
                PrimerNombre = parts[0],
                SegundoNombre = parts[1],
                PrimerApellido = parts[2],
                SegundoApellido = parts[3],
                Genero = (Genero)Enum.Parse(typeof(Genero), parts[4]),
                NumeroTelefonico = parts[5],
                Servicio = (Servicio)Enum.Parse(typeof(Servicio), parts[6]),
                Comentarios = parts[7]
            };
        }


        class Program
        {
            // Cambiar esta ruta a la ubicación deseada. Aquí se muestra un ejemplo para el escritorio.
            static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ccm.txt");

            static void Main(string[] args)
            {
                //corre al menos una vez
                do
                {
                    Reclamacion nuevoInforme = new Reclamacion();

                    ResetConsole();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0,-3} Sistema de recepción de quejas y sugerencias {0,-3}", "===");
                    Console.WriteLine("Los campos con (*) son obligatorios:");
                    Console.WriteLine("Digite su Primer Nombre:*");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.PrimerNombre = LeerCampo();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Digite su Segundo Nombre:");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.SegundoNombre = LeerCampo(false);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Digite su Primer Apellido:*");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.PrimerApellido = LeerCampo();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Digite su Segundo Apellido:");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.SegundoApellido = LeerCampo(false);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Elija su genero (1 = Omitido,2 = Masculino, 3 = Femenino):* ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.Genero = (Genero)LeerGenero();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Digite su Número Telefónico:* ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.NumeroTelefonico = LeerCampoNumero();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Elija su tipo de servicio (1 = Básico,2 = Plus, 3 = Premium):* ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.Servicio = (Servicio)LeerServicio();



                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Agregue sus Comentarios:");
                    Console.ForegroundColor = ConsoleColor.White;
                    nuevoInforme.Comentarios = LeerCampo(isOpen: true);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Su queja ha sido registrada exitósamente!");

                    GuardarDatos(nuevoInforme);


                }
                ///valida si el usuario desea continuar o no
                while (LeerContinuar());

                ImprimirInforme();
                Console.ReadLine();
                Console.ReadLine();
            }

            static string LeerCampo(bool isRequired = true, bool isOpen = false)
            {
                string input;
                do
                {
                    input = Console.ReadLine() ?? "";
                    if (!isOpen)
                    {
                        const string patron = @"^[a-zA-Z]+$";
                        if (Regex.IsMatch(input, patron))
                            break;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(input))
                            break;
                    }
                    if (isRequired || !string.IsNullOrEmpty(input))
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Este campo es obligatorio. Por favor, ingrese un valor de texto. ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (isRequired || !string.IsNullOrEmpty(input));
                if (string.IsNullOrEmpty(input))
                    return "N/D";
                return input;
            }
            static string LeerCampoNumero(bool isRequired = true)
            {
                string num = string.Empty;
                const string patron = @"^\d+$";
                do
                {
                    num = Console.ReadLine();                    

                    if (Regex.IsMatch(num, patron))
                        break;
                    if (isRequired)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Este campo es obligatorio. Por favor, ingrese un valor numérico.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (isRequired);
                return num;
            }

            /// <summary>
            /// Valida si el valor ingresado es un numero y si es valido para el rango del enum
            /// </summary>
            /// <returns></returns>
            static int LeerGenero()
            {
                int valor;
                while (true)
                {
                    //
                    if (int.TryParse(Console.ReadLine(), out valor) && Enum.IsDefined(typeof(Genero), valor))
                        break;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un valor válido.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return valor;
            }
            /// <summary>
            /// Valida si el valor ingresado es un numero y si es valido para el rango del enum
            /// </summary>
            /// <returns></returns>
            static int LeerServicio()
            {
                int valor;
                while (true)
                {
                    //
                    if (int.TryParse(Console.ReadLine(), out valor) && Enum.IsDefined(typeof(Servicio), valor))
                        break;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un valor válido.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return valor;
            }

            /// <summary>
            /// Valida si el usuario desea continuar o no
            /// </summary>
            /// <returns>bool</returns>
            static bool LeerContinuar()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¿Desea Continuar? Si (Y), No (N):");

                bool status = true;
                while (status)
                {
                    string input = Console.ReadKey().Key.ToString().ToUpper();


                    if (input == "Y" || input == "N")
                    {
                        status = input == "Y";
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debe presionar [y/n] para indicar si desea continuar con otro formulario!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return status;
            }

            /// <summary>
            /// Guarda la data en el escritorio
            /// </summary>
            /// <param name="datos"></param>
            static void GuardarDatos(Reclamacion datos)
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(datos.ToString());
                }
            }

            static void ImprimirInforme()
            {
                //verifica si el archivo existe
                if (!File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No hay datos registrados.");
                    Console.ResetColor();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Listado de datos registrados:");
                ///lee el archivo convierte toda la data a objetos e imprime en pantalla
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var info = Reclamacion.FromString(line);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Primer Nombre : {info.PrimerNombre}");
                    Console.WriteLine($"Segundo Nombre : {info.SegundoNombre}");
                    Console.WriteLine($"Primer Apellido {info.PrimerApellido}");
                    Console.WriteLine($"Segundo Apellido : {info.SegundoApellido}");
                    Console.WriteLine($"Genero : {info.Genero}");
                    Console.WriteLine($"Numero Telefonico : {info.NumeroTelefonico}");
                    Console.WriteLine($"Servicio : {info.Servicio}");
                    Console.WriteLine($"Comentarios:{info.Comentarios}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string('-', 40));
                }
                Console.ResetColor();
            }


            public static void ResetConsole()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
        }
    }
}
