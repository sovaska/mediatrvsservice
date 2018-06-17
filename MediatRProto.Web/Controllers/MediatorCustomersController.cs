using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRProto.Web.Controllers
{
    public class GetCustomers : IRequest<List<string>> { }

    public class GetCustomersHandler : IRequestHandler<GetCustomers, List<string>>
    {
        public Task<List<string>> Handle(GetCustomers request, CancellationToken cancellationToken)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(new List<string> { "Pong" });
        }
    }

    public class GetCustomer : IRequest<Customer>
    {
        public GetCustomer(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class GetCustomerHandler : IRequestHandler<GetCustomer, Customer>
    {
        public Task<Customer> Handle(GetCustomer request, CancellationToken cancellationToken)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(new Customer { Id = request.Id });
        }
    }

    public class PostCustomer : IRequest<Customer>
    {
        public PostCustomer(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }
    }

    public class PostCustomerHandler : IRequestHandler<PostCustomer, Customer>
    {
        public Task<Customer> Handle(PostCustomer request, CancellationToken cancellationToken)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(request.Customer);
        }
    }

    public class GetCustomerName : IRequest<string>
    {
        public GetCustomerName(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class GetCustomerNameHandler : IRequestHandler<GetCustomerName, string>
    {
        public Task<string> Handle(GetCustomerName request, CancellationToken cancellationToken)
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult("FooBar");
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MediatorCustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorCustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var response = await _mediator.Send(new GetCustomers());

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(string id)
        {
            var response = await _mediator.Send(new GetCustomer(id));
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            var response = await _mediator.Send(new PostCustomer(customer));
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("{id}/name")]
        public async Task<ActionResult<string>> GetName(string id)
        {
            var response = await _mediator.Send(new GetCustomerName(id));
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
    }
}
