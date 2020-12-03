using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TulaHealthCodeChallenge.Data;
using TulaHealthCodeChallenge.Domain;

namespace TulaHealthCodeChallenge.Services
{
    public class TableOneService
    {
        private readonly HttpClient _httpClient;

        public TableOneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetOrders()
        {
            var data = await _httpClient.GetStreamAsync($"api/orders");
            var json = data.ToString();
            var tableList = JsonConvert.DeserializeObject<IEnumerable<Order>>(json).ToList();
            return tableList;
        }
    }
}
