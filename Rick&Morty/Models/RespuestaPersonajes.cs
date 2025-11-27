using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rick_Morty.Models
{
    public class RespuestaPersonajes
    {
        [JsonProperty("results")]
        public List<Personaje> Results { get; set; }
    }
}
