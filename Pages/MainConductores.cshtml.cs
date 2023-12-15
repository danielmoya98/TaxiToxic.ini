using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaxiToxic.ini.Pages
{
    public class MainConductores : PageModel
    {
        public List<Driver> Drivers { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7293/api/Driver/3");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Driver driver = JsonConvert.DeserializeObject<Driver>(apiResponse);
                        Drivers = new List<Driver> { driver }; // Envuelve el único conductor en una lista
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
    }

    public class Driver
    {
        public int Id_Driver { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public int CI { get; set; }
        public int Identification { get; set; }
        public int License { get; set; }
        public short Category { get; set; }
        public int PhoneNumber { get; set; }
        public int ReferencePhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Entry { get; set; }
        public int CompanyId { get; set; }

        // Otras propiedades, si las necesitas
    }
}
