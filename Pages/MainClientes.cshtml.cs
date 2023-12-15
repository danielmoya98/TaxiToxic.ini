using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace TaxiToxic.ini.Pages
{
    public class MainClientes : PageModel
    {
        public List<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7293/api/Customer");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    }
                    else
                    {
                        // Maneja el código de estado no exitoso
                    }
                }
                catch (Exception ex)
                {
                    // Maneja la excepción
                }
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7293/api/Customer/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        // La eliminación en la base de datos fue exitosa
                        // Puedes realizar alguna lógica adicional si es necesario
                    }
                    else
                    {
                        // Maneja el código de estado no exitoso
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción
            }

            // Redirige a alguna otra página después de eliminar el carro
            return RedirectToPage("/MainClientes"); // Cambia "/MainTaxis" con la ruta de tu página actual
        }
    }


    public class Customer
    {
        [Key]
        public int Id_Customer { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string StartTimeState { get; set; } = null!;
        public string EndTimeState { get; set; } = null!;
        public DateTime LastAccess { get; set; }
    }
}
