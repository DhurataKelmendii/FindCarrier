using FindCarrier.Domain;
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
    public class UserService
    {
        private readonly UserRepository _userRepository;
   
        public UserService(IRepository<User> userRepository,
            CarrierDbContext context)
        {
            _userRepository = new UserRepository(userRepository, context);

        }

        public async Task<bool> Create(User user)
        {
            var result = await _userRepository.Create(user);

            return result;
        }

        public async Task<bool> Update(User user)
        {
            var updatedSuccefully = await _userRepository.Update(user);


            return updatedSuccefully;
        }


        public async Task<IList<User>> GetAll()
        {
            var result = await _userRepository.GetAll();

            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _userRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);
            return deleted;
        }

    }
}

