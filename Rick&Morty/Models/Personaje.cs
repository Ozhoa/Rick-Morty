using Newtonsoft.Json;

namespace Rick_Morty.Models
{
    public class Personaje
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("status")]
        public string Estado { get; set; }

        [JsonProperty("species")]
        public string Especie { get; set; }

        [JsonProperty("image")]
        public string Imagen { get; set; }

        [JsonProperty("gender")]
        public string Genero { get; set; }
    }
}
