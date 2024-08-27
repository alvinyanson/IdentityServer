
using API.Models;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public partial class Shops
    {

        private List<CoffeeShopModel> CoffeeShops = new();

        [Inject]
        private HttpClient HttpClient { get; set; }

        [Inject]
        private IConfiguration Config { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await HttpClient.GetAsync(Config["apiUrl"] + "/api/CoffeeShop");

            if (result.IsSuccessStatusCode)
            {
                CoffeeShops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();
            }
        }
    }
}
