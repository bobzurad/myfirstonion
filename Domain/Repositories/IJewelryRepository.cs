using Domain.Models;

namespace Domain.Repositories
{
    public interface IJewelryRepository
    {
        Jewelry GetById(int id);
    }
}
