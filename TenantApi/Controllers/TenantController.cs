using Microsoft.AspNetCore.Mvc;
using TenantApi.DataAccess;
using TenantApi.Models;

namespace TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly IRepository _repository;
        public TenantController()
        {
                _repository = new Repository();
        }

        [HttpGet]
        [Route("[controller]/Index")]
        public string Get()
        {
            return "I am Tenant API";
        }

        [HttpGet]
        [Route("[controller]/Sample")]
        public Task<List<User>> GetAll()
        {
            return _repository.GetAllUsers();
        }

        [HttpPost]
        [Route("[controller]/Save")]
        public void Post(User user)
        {
            _repository.CreateUser(user);
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public void Delete(User user)
        {
            _repository.DeleteUser(user);
        }
    }
}