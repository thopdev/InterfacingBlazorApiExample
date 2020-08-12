using System.Threading.Tasks;
using BlazorAPI.Shared.Interfaces;
using BlazorAPI.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAPI.Client.Pages
{
    public partial class CreateDog
    {
        [Inject] public IDogEndpoint DogEndpoint { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public string Name { get; set; }
        private readonly DogDto _dog = new DogDto();

        public async Task Create()
        {
            await DogEndpoint.Create(_dog);
            NavigationManager.NavigateTo("/");
        }
    }
}
