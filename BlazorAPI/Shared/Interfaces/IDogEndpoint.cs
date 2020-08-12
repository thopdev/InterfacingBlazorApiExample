using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Shared.Interfaces
{
    public interface IDogEndpoint
    {
        [HttpGet]
        Task<List<DogDto>> Get();

        [HttpGet("{name}")]
        Task<DogDto> Get(string name);

        [HttpPost]
        Task<DogDto> Create([FromBody] DogDto body);

        [HttpPost("{name}")]
        Task<DogDto> Edit(string name, [FromBody] DogDto body);

        [HttpDelete("{name}")]
        Task Delete(string name);
    }
}
