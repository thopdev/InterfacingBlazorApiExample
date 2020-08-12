using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAPI.Shared.Interfaces;
using BlazorAPI.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAPI.Client.Pages
{
    public partial class Dog
    {
        [Inject] public IDogEndpoint DogEndpoint { get; set; }
        [Parameter] public string Name { get; set; }

        private DogDto _dog;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _dog = await DogEndpoint.Get(Name);
        }
    }
}
