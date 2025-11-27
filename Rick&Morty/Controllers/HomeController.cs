using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Rick_Morty.Models;

namespace Rick_Morty.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseUrl = "https://rickandmortyapi.com/api";

        public async Task<ActionResult> Index()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync($"{baseUrl}/character");
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "No se pudo obtener la lista de personajes.";
                    return View(new List<Personaje>());
                }

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<RespuestaPersonajes>(json);

                return View(data?.Results ?? new List<Personaje>());
            }
        }

        public async Task<ActionResult> Detalles(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync($"{baseUrl}/character/{id}");
                if (!response.IsSuccessStatusCode) return HttpNotFound();

                var json = await response.Content.ReadAsStringAsync();
                var personaje = JsonConvert.DeserializeObject<Personaje>(json);

                if (personaje == null) return HttpNotFound();

                return View("Detalles", personaje);
            }
        }
    }
}
