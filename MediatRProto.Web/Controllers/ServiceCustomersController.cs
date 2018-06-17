using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatRProto.Web.Controllers
{
    public interface ICustomersService
    {
        Task<List<string>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(string id);
        Task<string> GetCustomerNameAsync(string id);
        Task<Customer> PostCustomerAsync(Customer customer);
    }

    public class CustomersService : ICustomersService
    {
        public Task<List<string>> GetCustomersAsync()
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(new List<string> { "Pong" });
        }

        public Task<Customer> GetCustomerAsync(string id)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(new Customer { Id = id });
        }

        public Task<string> GetCustomerNameAsync(string id)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult("FooBar");
        }

        public Task<Customer> PostCustomerAsync(Customer customer)
        {
            // TODO: Write to repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(customer);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public ServiceCustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var response = await _customersService.GetCustomersAsync();

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(string id)
        {
            var response = await _customersService.GetCustomerAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            var response = await _customersService.PostCustomerAsync(customer);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("{id}/name")]
        public async Task<ActionResult<string>> GetName(string id)
        {
            var response = await _customersService.GetCustomerNameAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
    }
}
