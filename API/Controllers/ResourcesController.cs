using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ResourcesController : BaseApiController
    {
        private readonly IGenericRepository<Resource> _repository;
        private readonly IMapper _mapper;

        public ResourcesController(IGenericRepository<Resource> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResourceToReturnDto>>> GetResources()
        {
            var resources = await _repository.ListAllAsync();

            return _mapper.Map<List<Resource>, List<ResourceToReturnDto>>(resources);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResourceToReturnDto>> GetResource(int id)
        {
            var resource = await _repository.GetByIdAsync(id);

            if(resource == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Resource, ResourceToReturnDto>(resource);
        }
    }
}
