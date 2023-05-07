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
    public class UniversityService
    {
        private readonly UniversityRepository _uniRepository;

        public UniversityService(IRepository<University> repository)
        {
            _uniRepository = new UniversityRepository(repository);
        }

        public async Task<bool> Create(University university)
        {
            var result = await _uniRepository.Create(university);
            return result;
        }

        public async Task<bool> Update(University university)
        {
            var updatedSuccessfully = await _uniRepository.Update(university);

            return updatedSuccessfully;
        }

        public async Task<IList<University>> GetAll()
        {
            var result = await _uniRepository.GetAll();
            return result;
        }

        public async Task<bool> DeleteUniversity(int id)
        {
            var deleted = await _uniRepository.DeleteUniversity(id);
            return deleted;
        }

        public async Task<University> GetById(int id)
        {
            var result = await _uniRepository.GetById(id);
            return result;
        }
    }
}

