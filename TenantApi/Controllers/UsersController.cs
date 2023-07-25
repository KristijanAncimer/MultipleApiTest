using Microsoft.AspNetCore.Mvc;
using TenantApi.Commands;
using TenantApi.DataAccess;
using TenantApi.Models;

namespace TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repository;


        public UsersController()
        {
            _repository = new Repository();
        }

        [HttpGet]
        [Route("[controller]/All")]
        public Task<List<User>> GetAll()
        {
            return _repository.GetAllUsers();
        }

        [HttpGet]
        [Route("[controller]/GetById/{id}")]
        public Task<User> GetById(Guid id)
        {
            return _repository.GetById(id); 
        }

        [HttpPost]
        [Route("[controller]")]
        public Task<User> CreateUser(CreateUserCmd cmd)
        {
            return _repository.CreateUserAsync(cmd);
        }
    }
}
