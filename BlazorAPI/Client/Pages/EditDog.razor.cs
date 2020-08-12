using System.Threading.Tasks;
using BlazorAPI.Shared.Interfaces;
using BlazorAPI.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAPI.Client.Pages
{
    public partial class EditDog
    {
        [Inject] public IDogEndpoint DogEndpoint { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public string Name { get; set; }
        private DogDto _dog;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _dog = await DogEndpoint.Get(Name);
        }

        public async Task Edit()
        {
            await DogEndpoint.Edit(Name, _dog);
            NavigationManager.NavigateTo("/");
        }
    }
}
