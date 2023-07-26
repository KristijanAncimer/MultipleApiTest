using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TenantApi.Commands;
using TenantApi.DataAccess;
using TenantApi.Models;

namespace TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IRepository _repository;
        private readonly IGenericRepository _genericRepository;

        public UsersController(IConfiguration configuration,IGenericRepository genericRepository)
        {
            _configuration = configuration;
            _repository = new Repository();
            _genericRepository=genericRepository;
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
