using FindCarrier.Domain.Entities;
using FindCarrier.Models.ViewModels;
using FindCarrier.Repositories.Repositories;
using FindCarrier.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindCarrier.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        //dependency injection
        private readonly UniversityService uniService;
        public UniversityController(IRepository<University> repository)
        {
            uniService = new UniversityService(repository);
        }

        [HttpGet]
        [Route("UniversitiesList")]
        public async Task<ActionResult<IEnumerable<University>>> UniversitiesList()
        {
            var model = new UniversityViewModel();
            var result = (await uniService.GetAll()).Select(x => new UniversityViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Place = x.Place,
                Field = x.Field,
                SchoolType = x.SchoolType,
                Location = x.Location,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.University = result;
            return Ok(model);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<University>>> Search(string searchPlace)
        {
            var model = new UniversityViewModel();
            var universities = await uniService.GetAll();

            var filteredUniversities = universities.Where(x => x.Place == searchPlace)
                                                   .Select(x => new UniversityViewModel
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Place = x.Place,
                                                       Field = x.Field,
                                                       SchoolType = x.SchoolType,
                                                       Location = x.Location,
                                                       IsDeleted = x.IsDeleted
                                                   })
                                                   .ToList();

            model.University = filteredUniversities;
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)  
        {
            var uni = await uniService.GetById(id);
            if (uni == null)
            {
                return NotFound();
            }
            return uni;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UniversityViewModel uniViewModel)
        {
            if (uniViewModel != null)
            {
                var model = new University()
                {
                    Id = uniViewModel.Id,
                    Name = uniViewModel.Name,
                    Place = uniViewModel.Place,
                    SchoolType = uniViewModel.SchoolType,
                    Location = uniViewModel.Location,
                    Field = uniViewModel.Field,
                    IsDeleted = false

                };
                var saveSuccessful = await uniService.Create(model);

                if (saveSuccessful)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            var result = await uniService.DeleteUniversity(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
