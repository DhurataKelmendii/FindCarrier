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
        public async Task<ActionResult<IEnumerable<University>>> GetUniversities()
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

        [HttpGet("{id}")]
        //[Route("GetById/{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)
        {
            var uni = await uniService.GetById(id);
            if (uni == null)
            {
                return NotFound();
            }
            return uni;
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUniversity(int id, University uni)
        //{
        //    if (id != uni.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(uni).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UniversityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

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
