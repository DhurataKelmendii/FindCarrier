using FindCarrier.Domain;
using FindCarrier.Domain.Entities;
using FindCarrier.Models.ViewModels;
using FindCarrier.Repositories.Repositories;
using FindCarrier.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindCarrier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        //dependency injection
        private readonly JobService jobService;
        public JobController(IRepository<Job> repository)
        {
            jobService = new JobService(repository);
        }

        [HttpGet]
        [Route("JobsList")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            var model = new JobViewModel();
            var result = (await jobService.GetAll()).Select(x => new JobViewModel
            {
                JobName = x.JobName,
                Place = x.Place,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Job = result;
            return Ok(model);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Job>>> SearchJobs(string searchPlace)
        {
            var model = new JobViewModel();
            var universities = await jobService.GetAll();

            var filteredJobs = universities.Where(x => x.Place == searchPlace)
                                                   .Select(x => new JobViewModel
                                                   {
                                                       Id = x.Id,
                                                       JobName = x.JobName,
                                                       Place = x.Place,
                                                       IsDeleted = x.IsDeleted
                                                   })
                                                   .ToList();

            model.Job = filteredJobs;
            return Ok(model);
        }

        [HttpGet("{id}")]
        //[Route("GeById/{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await jobService.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            return job;
        }

        [HttpPost]
        //[Route("Create")]
        public async Task<IActionResult> Create([FromBody] JobViewModel jobViewModel)
        {
            if (jobViewModel != null)
            {
                var model = new Job()
                {
                    Id = jobViewModel.Id,
                    JobName = jobViewModel.JobName,
                    Place = jobViewModel.Place,
                    IsDeleted = jobViewModel.IsDeleted

                };
                var saveSuccessful = await jobService.Create(model);

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
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await jobService.DeleteJob(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
