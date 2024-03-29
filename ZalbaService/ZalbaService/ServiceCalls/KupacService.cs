﻿using ZalbaService.Models;
using Newtonsoft.Json;

namespace ZalbaService.ServiceCalls
{
    public class KupacService:IKupacService
    {
        private readonly IConfiguration configuration;
        public KupacService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<KupacInfoDto> GetKupacById(Guid KupacID)
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
                    var kupac = JsonConvert.DeserializeObject<KupacInfoDto>(responseString);
                    return kupac;
                }
                return default;

            }
        }
    }
}
