using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAPI.Shared.Interfaces;
using BlazorAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase, IDogEndpoint
    {
        public static readonly IDictionary<string, DogDto> Dogs = new Dictionary<string, DogDto>
        {
            {"Joey", new DogDto {Age = 5, Name = "Joey"}},
            {"Barky", new DogDto {Age = 8, Name = "Barky"}},
            {"Cooper", new DogDto {Age = 2, Name = "Cooper"}},
            {"SnoopDog", new DogDto {Age = 500, Name = "SnoopDog"}}
        };

        [HttpGet]
        public Task<List<DogDto>> Get()
        {
            return Task.FromResult(Dogs.Values.ToList());
        }

        [HttpGet("{name}")]
        public Task<DogDto> Get(string name)
        {
            return Task.FromResult(Dogs[name]);
        }

        [HttpPost]
        public Task<DogDto> Create([FromBody] DogDto body)
        {
            Dogs.Add(body.Name, body);
            return Task.FromResult(body);
        }

        [HttpPost("{name}")]
        public Task<DogDto> Edit(string name, [FromBody] DogDto body)
        {
            Dogs[name] = body;
            return Task.FromResult(body);
        }

        [HttpDelete("{name}")]
        public Task Delete(string name)
        {
            Dogs.Remove(name);
            return Task.CompletedTask;
        }
    }
}