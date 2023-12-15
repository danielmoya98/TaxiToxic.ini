using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static TaxiToxic.ini.Pages.MainTaxis;

namespace TaxiToxic.ini.Pages;

public class MainTaxis : PageModel
{
    public List<Car> Cars { get; set; } = new List<Car>();

    public async Task OnGetAsync()
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7293/api/Cars");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Cars = JsonConvert.DeserializeObject<List<Car>>(apiResponse);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7293/api/Cars/{id}");

                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    
                }
            }
        }
        catch (Exception ex)
        {

        }

        return RedirectToPage("/MainTaxis");
    }


    public class Car
    {
        public int Id_Car { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Plate { get; set; } = null!;
        public int Capacity { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string AlarmStatus { get; set; } = null!;
    }
}