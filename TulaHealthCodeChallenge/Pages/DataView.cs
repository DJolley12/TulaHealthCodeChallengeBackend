using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TulaHealthCodeChallenge.Domain;
using TulaHealthCodeChallenge.Services;

namespace TulaHealthCodeChallenge.Pages
{
    public partial class DataView : ComponentBase
    {
        private List<Order> tableOnes { get; set; }

        [Inject]
        private TableOneService tableOneService { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async override Task OnInitializedAsync()
        {
            tableOnes = await tableOneService.GetOrders();
        }
    }
}
