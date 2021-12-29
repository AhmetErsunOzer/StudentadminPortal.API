using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList=await _studentRepository.GetGendersAsync();
            if (genderList==null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<GenderDM>>(genderList));
        }
    }
}
