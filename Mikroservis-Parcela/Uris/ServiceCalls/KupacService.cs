﻿using Newtonsoft.Json;
using Uris.DTO;

namespace Uris.ServiceCalls
{
    public class KupacService : IKupacService
    {
        private readonly IConfiguration configuration;
        public KupacService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<KupacDto> GetKupacById(Guid KupacID)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:KupacService"]}api/kupac/vo/" + KupacID);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var kupac = JsonConvert.DeserializeObject<KupacDto>(responseString);
                    return kupac;
                }
                return default;

            }
        }
    }
}
