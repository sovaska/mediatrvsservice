using MediatRProto.Web.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace MediatRProto.Test
{
    public class ServiceTests
    {
        private ICustomersService Sut { get; set; }

        public ServiceTests()
        {
            Sut = new CustomersService();
        }

        [Fact]
        public async Task GetCustomerTest()
        {
            var expected = "1";

            var result = await Sut.GetCustomerAsync(expected);

            Assert.Equal(expected, result.Id);
        }
    }
}
