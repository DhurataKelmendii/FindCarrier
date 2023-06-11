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
    public class UniversityApplicationService
    {
        private readonly UniversityApplicationRepository _uniAppRepository;

        public UniversityApplicationService(IRepository<UniversityApplication> repository)
        {
            _uniAppRepository = new UniversityApplicationRepository(repository);
        }

        public async Task<bool> ApplyForUni(UniversityApplication application)
        {
            var result = await _uniAppRepository.ApplyForUni(application);
            return result;
        }
        
        public async Task<bool> ApplyForCarrier(UniversityApplication application)
        {
            var result = await _uniAppRepository.ApplyForUni(application);
            return result;
        }

        public async Task<IList<UniversityApplication>> GetAll()
        {
            var result = await _uniAppRepository.GetAll();
            return result;
        }

        public async Task<bool> DeleteApplication(int id)
        {
            var deleted = await _uniAppRepository.DeleteApplication(id);
            return deleted;
        }

        public async Task<UniversityApplication> GetById(int id)
        {
            var result = await _uniAppRepository.GetById(id);
            return result;
        }
    }
}

