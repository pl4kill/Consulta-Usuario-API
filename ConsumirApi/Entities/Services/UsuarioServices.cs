using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi.Entities.Services
{
    internal class UsuarioServices
    {
        public async Task<Usuarios> Integracao(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://dummyjson.com/user/{id}");
            var JsonSrt = await response.Content.ReadAsStringAsync();

            Usuarios jsonObjeto = JsonConvert.DeserializeObject<Usuarios>(JsonSrt);

            if(jsonObjeto != null)
            {
                return jsonObjeto;
            }
            else
            {
                return new Usuarios { verificador = true };
            }

        }
    }
}
