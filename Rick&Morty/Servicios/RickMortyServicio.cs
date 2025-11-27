using Newtonsoft.Json;
using Rick_Morty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Rick_Morty.Servicios
{
    public class RickMortyServicio
    {
        private static readonly HttpClient cliente = new HttpClient
        {
            BaseAddress = new Uri("https://rickandmortyapi.com/api/")
        };

        // Obtener lista completa de personajes
        public async Task<RespuestaPersonajes> ObtenerPersonajesAsync()
        {
            var respuesta = await cliente.GetAsync("character");
            respuesta.EnsureSuccessStatusCode();

            var json = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RespuestaPersonajes>(json);
        }

        // Obtener un personaje por ID
        public async Task<Personaje> ObtenerPersonajePorIdAsync(int id)
        {
            var respuesta = await cliente.GetAsync("character/" + id);
            respuesta.EnsureSuccessStatusCode();

            var json = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Personaje>(json);
        }
    }
}