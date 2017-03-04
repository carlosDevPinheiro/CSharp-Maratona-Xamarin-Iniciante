using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace TesteXamarinForms
{
    public class Restclient
    {
        public string Serialize()
        {
            var paises = new[]
            {
                new Country { Name = "Mexico"},
                new Country { Name = "Costa Rica" }
            };

            string json = JsonConvert.SerializeObject(paises);

            Debug.WriteLine( $"********************************** {json} ************");

            return json;
        }

        public void Deserialize()
        {
            var json = Serialize();

            var parsedJson = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

            foreach (Country item in parsedJson)
            {
                Debug.WriteLine(item.Name);
            }
        }

        #region Metodo usado sem HttpClient
        //public Country[] GetCountries()
        //{
        //    var paises = new[]
        //     {
        //        new Country { Name = "Mexico"},
        //        new Country { Name = "Costa Rica" }
        //    };

        //    return paises;
        //} 
        #endregion

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await GetAsJson();
        }

        public string BaseUrl { get; set; } = "http://restcountries.eu/rest/v1";



        protected async Task<IEnumerable<Country>> GetAsJson()
        {
            var result = Enumerable.Empty<Country>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(BaseUrl).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(json))
                    {
                        result = await Task.Run(() =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                        }).ConfigureAwait(false);
                    }
                }

                return result;
            }
        }
    }
}
