using System.Text.Json;
using System.Text.Json.Serialization;
public class Program
{
    static async Task Main(string[] args)
    {
        List<Estudiante> estudiantes = await DummyAPI.GetUsersAsync();  
        // Mostrar la información de los estudiantes
        foreach (Estudiante estudiante in estudiantes)
        {
            estudiante.Talk();
        }
        Console.Read();
    }
    /// <summary>
    /// API que usa el servicio de DummyJSON para usar data para pruebas.
    /// </summary>
    public static class DummyAPI
    {
        const string baseUrl = "https://dummyjson.com/";
        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };

        // Método para obtener usuarios
        public static async Task<List<Estudiante>> GetUsersAsync(int limit = 5)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"users/?limit={limit}");
            response.EnsureSuccessStatusCode();
            string content= await response.Content.ReadAsStringAsync();
            User[] usr = JsonSerializer.Deserialize<ServerResponse>(content).users;
            string udata= JsonSerializer.Serialize(usr);
            var students = JsonSerializer.Deserialize<List<Estudiante>>(udata);
            return students;
        }

        // Método para obtener un usuario por ID
        public static async Task<string> GetUserByIdAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"users/{id}"); response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    public class Estudiante
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("StudentID")]
        public string Matricula
        {
            get
            {
                return $"{FechaDeIngreso.Year}-{new Random().Next(1000, 9999)}";
            }
        }
        [JsonPropertyName("firstName")]
        public string Nombre { get; set; }
        [JsonPropertyName("lastName")]
        public string Apellido { get; set; }
        [JsonPropertyName("gender")]
        public string Genero { get; set; }
        [JsonPropertyName("birthDate")]
        public DateTime FechaDeIngreso { get; set; } = new();

        public Estudiante() { }

        internal void Talk()
        {
            Console.WriteLine($"Matricula: {Matricula}, Nombre: {Nombre}, Género: {Genero}, Fecha de Ingreso: {FechaDeIngreso.ToShortDateString()}");
        }
    }
    #region foo
    public class ServerResponse
    {
        public User[] users { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string maidenName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string birthDate { get; set; }
        public string image { get; set; }
        public string bloodGroup { get; set; }
        public int height { get; set; }
        public float weight { get; set; }
        public string eyeColor { get; set; }
        public Hair hair { get; set; }
        public string domain { get; set; }
        public string ip { get; set; }
        public Address address { get; set; }
        public string macAddress { get; set; }
        public string university { get; set; }
        public Bank bank { get; set; }
        public Company company { get; set; }
        public string ein { get; set; }
        public string ssn { get; set; }
        public string userAgent { get; set; }
        public Crypto crypto { get; set; }
    }

    public class Hair
    {
        public string color { get; set; }
        public string type { get; set; }
    }

    public class Address
    {
        public string address { get; set; }
        public string city { get; set; }
        public Coordinates coordinates { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
    }

    public class Coordinates
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Bank
    {
        public string cardExpire { get; set; }
        public string cardNumber { get; set; }
        public string cardType { get; set; }
        public string currency { get; set; }
        public string iban { get; set; }
    }

    public class Company
    {
        public Address1 address { get; set; }
        public string department { get; set; }
        public string name { get; set; }
        public string title { get; set; }
    }

    public class Address1
    {
        public string address { get; set; }
        public string city { get; set; }
        public Coordinates1 coordinates { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
    }

    public class Coordinates1
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Crypto
    {
        public string coin { get; set; }
        public string wallet { get; set; }
        public string network { get; set; }
    }
    #endregion
}