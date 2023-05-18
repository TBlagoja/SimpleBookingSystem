using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceRepository _repository;

        public ResourcesController(IResourceRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Resource>>> GetResources()
        {
            var resources = await _repository.GetResourcesAsync();

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResource(int id)
        {
            var resource = await _repository.GetResourcesByIdAsync(id);

            return resource;
        }
    }
}
