using Microsoft.AspNetCore.Components;
using MinimalAPIs.Data;
using MinimalAPIsBlazorServerClient.Model;
using System.Text.Json;

namespace MinimalAPIsBlazorServerClient.Pages
{
    public partial class Syscode : ComponentBase
    {
        [Inject] private IHttpClientFactory? ClientFactory { get; set; }
        
        private IEnumerable<SYSCODE>? ListSyscode = Array.Empty<SYSCODE>();

        private SyscodeModel Model { get; set; } = new SyscodeModel();

        protected override async Task OnInitializedAsync()
        {
            await OnGetData();
        }

        private async Task Query()
        {
            await OnGetData();
        }

        public async Task OnGetData()
        {
            string url = $"https://localhost:7136/syscodes/{Model.CKIND}";

            //using (var http = new HttpClient())
            //{
            //    var list = await http.GetFromJsonAsync<List<SYSCODE>>(url);
            //    if (list != null)
            //    {
            //        ListSyscode = list;
            //    }
            //}

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                ListSyscode = await JsonSerializer.DeserializeAsync
                    <List<SYSCODE>>(responseStream);

            }
            else
            {
                //Error
            }
        }
    }
}