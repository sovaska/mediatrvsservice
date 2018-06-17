using MediatRProto.Web.Controllers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MediatRProto.Test
{
    public class MediatRUnitTests
    {
        private IRequestHandler<GetCustomer, Customer> Sut { get; set; }

        public MediatRUnitTests()
        {
            Sut = new GetCustomerHandler();
        }

        [Fact]
        public async Task GetCustomerTest()
        {
            var expected = "1";
            var data = new GetCustomer(expected);

            var result = await Sut.Handle(data, CancellationToken.None);

            Assert.Equal(expected, result.Id);
        }
    }
}
