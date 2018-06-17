using System.ComponentModel.DataAnnotations;

namespace MediatRProto.Web.Controllers
{
    public class Customer
    {
        [Required, MaxLength(50)]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
