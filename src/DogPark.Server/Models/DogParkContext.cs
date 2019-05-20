using Microsoft.EntityFrameworkCore;

namespace DogPark.Server.Models
{
    public class DogParkContext : DbContext
    {
        public DogParkContext(DbContextOptions<DogParkContext> options) :
            base(options)
        {
        }
    }
}
