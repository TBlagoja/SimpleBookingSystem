﻿using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ResourcesController : BaseApiController
    {
        private readonly IGenericRepository<Resource> _resourceRepository;
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IDateValidationService _validationService;

        public ResourcesController(IGenericRepository<Resource> resourceRepository,
                                   IGenericRepository<Booking> bookingRepository,
                                   IMapper mapper,
                                   IDateValidationService validationService)
        {
            _resourceRepository = resourceRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _validationService = validationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResourceToReturnDto>>> GetResources()
        {
            var resources = await _resourceRepository.ListAllAsync();

            return _mapper.Map<List<Resource>, List<ResourceToReturnDto>>(resources);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResourceToReturnDto>> GetResource(int id)
        {
            var resource = await _resourceRepository.GetByIdAsync(id);

            if (resource == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Resource, ResourceToReturnDto>(resource);
        }

        [HttpPost("book")]
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)
        {
            //var bookingToAdd = _mapper.Map<BookingToAddDto, Booking>(booking);

            var validationResponse = await _validationService.ValidateDate(booking);

            if (validationResponse.IsValid)
            {
                var addedBooking = await _bookingRepository.AddAsync(booking);

                return Ok(addedBooking ?? new Booking());
            }

            return BadRequest(validationResponse);
        }
    }
}
