using System.Net;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, 
            ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries =await _unitOfWork.countryRepository.GetAllAsync();
                return Ok(_mapper.Map<IList<CountryDTO>>(countries));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, 
                    "Something went wrong in the GetCountries Method of Controller");
                return StatusCode( (int)HttpStatusCode.InternalServerError, "Some thing went wrong");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.countryRepository.GetAsync(e => e.Id == id, new List<string>() {"Hotels", "Hotel"});
                return Ok(_mapper.Map<CountryDTO>(country));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Something went wrong in the GetCountries Method of Controller");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Some thing went wrong");
            }
        }
    }
}
