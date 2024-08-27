
using API.Models;
using Client.Services;
using IdentityModel.Client;
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

        [Inject]
        private ITokenService TokenService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenResponse = await TokenService.GetToken("CoffeeAPI.read");
            HttpClient.SetBearerToken(tokenResponse.AccessToken);

            var result = await HttpClient.GetAsync(Config["apiUrl"] + "/api/CoffeeShop");

            if (result.IsSuccessStatusCode)
            {
                CoffeeShops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();
            }
        }
    }
}
