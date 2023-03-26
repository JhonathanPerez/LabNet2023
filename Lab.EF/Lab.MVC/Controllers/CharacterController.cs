using Lab.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        public async Task<ActionResult> Index()
        {
            var url = "https://rickandmortyapi.com/api/character";
            List<CharacterJson> characterInfo = new List<CharacterJson>();

            using (var client = new HttpClient())
            {
               client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(url);

                if (Res.IsSuccessStatusCode)
                {
                    var charcaterResponse = Res.Content.ReadAsStringAsync().Result;

                    var characterString = JObject.Parse(charcaterResponse)["results"].ToString();

                    characterInfo = JsonConvert.DeserializeObject<List<CharacterJson>>(characterString);
                }
            }

            return View(characterInfo);
        }
    }
}