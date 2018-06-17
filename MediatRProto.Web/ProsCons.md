# Pros/Cons

Note: Fluent validation is not included in this proto since it's not directly related to MediatR

## MediatR

- Requires two classes (IRequest, IRequestHandler) for each controller action
- Classes are small
- No need to configure DI if only single implementation of action
- Required return value in three places:


    public class GetCustomer : IRequest<Customer> // 1
    {
        public GetCustomer(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class GetCustomerHandler : IRequestHandler<GetCustomer, Customer> // 2
    {
        public Task<Customer> Handle(GetCustomer request, CancellationToken cancellationToken) // 3
        {
            // TODO: Read from repository (EF, CosmosDB, Blob, DataLake, Search, ...)
            return Task.FromResult(new Customer { Id = request.Id });
        }
    }

## Service

- One service class includes all logic related to Entity (Customer in this case), however class could get bit if a lot of functionality
- Need to configure DI for Service
- Testing is a bit simpler (no need to new IRequest)