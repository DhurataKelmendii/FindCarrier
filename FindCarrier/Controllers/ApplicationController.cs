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
    public class ApplicationController : ControllerBase
    {
        //dependency injection
        private readonly UniversityApplicationService uniAppService;
        public ApplicationController(IRepository<UniversityApplication> repository)
        {
            uniAppService = new UniversityApplicationService(repository);
        }


        [HttpPost]
        [Route("ApplyForUniversity")]
        public async Task<IActionResult> ApplyForUniversity([FromBody] ResumeViewModel resumeModel)
        {
            if (resumeModel != null)
            {
                var resume = new Resume()
                {
                    Id = resumeModel.Id,
                    FullName = resumeModel.FullName,
                    Email = resumeModel.Email,
                    Phone = resumeModel.Phone,
                    Address = resumeModel.Address,
                    Nationality = resumeModel.Nationality,
                    Education = resumeModel.Education,
                    WorkExperience = resumeModel.WorkExperience,
                    Skills = resumeModel.Skills,
                    Certifications = resumeModel.Certifications
                };
                // Save the application
                var application = new UniversityApplication
                {
                    Resume = resume,
                    AppliedDate = DateTime.Now
                };
                var resumeApplication = await uniAppService.ApplyForUni(application);
                if (resumeApplication)
                {
                    return Ok(true);
                }
                // Send the application to the university 
                //await SendApplicationToUniversity(application){
               
                //}
                else
                {
                    return Ok(false);
                }
            }
            else{
                return BadRequest();
            }
        }

        //[HttpPost]
        //[Route("ApplyForCarrier")]
        //public async Task<IActionResult> ApplyForCarrier([FromBody] UniversityApplicationViewModel uaModel)
        //{
        //    if (uaModel != null)
        //    {
        //        var model = new UniversityApplication()
        //        {
        //            Resume = uaModel.Resume,
        //            AppliedDate = DateTime.Now

        //        };
        //        var resumeApplication = await uniAppService.ApplyForCarrier(model);
        //        if (resumeApplication)
        //        {
        //            return Ok(true);
        //        }
        //        // Send the application to the university 
        //        //await SendApplicationToUniversity(application){

        //        //}
        //        else
        //        {
        //            return Ok(false);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //public async Task SendApplicationToUniversity(UniversityApplication application)
        //{
        //    // Perform any necessary formatting or preparation of the application data

        //    // Send the application to the university using the appropriate method or API
        //    // Example: Call an external API to send the application data
        //    // Example: Use a messaging system or email to send the application data
        //    // Example: Save the application to a shared location for the university to retrieve

        //    // You can implement the specific logic for sending the application here
        //}
    }
}
