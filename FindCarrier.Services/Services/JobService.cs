using FindCarrier.Domain.Entities;
using FindCarrier.Repositories;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.Services
{
    public class JobService
    {
        private readonly JobRepository _jobRepository;

        public JobService(IRepository<Job> repository)
        {
            _jobRepository = new JobRepository(repository);
        }

        public async Task<bool> Create(Job job)
        {
            var result = await _jobRepository.Create(job);
            return result;
        }

        public async Task<bool> Update(Job job)
        {
            var updatedSuccessfully = await _jobRepository.Update(job);

            return updatedSuccessfully;
        }

        public async Task<IList<Job>> GetAll()
        {
            var result = await _jobRepository.GetAll();
            return result;
        }

        public async Task<bool> DeleteJob(int id)
        {
            var deleted = await _jobRepository.DeleteJob(id);
            return deleted;
        }

        public async Task<Job> GetById(int id)
        {
            var result = await _jobRepository.GetById(id);
            return result;
        }
    }
}
