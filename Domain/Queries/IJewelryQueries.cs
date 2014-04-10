using System.Collections.Generic;
using Domain.Models;

namespace Domain.Queries
{
    public interface IJewelryQueries
    {
        IEnumerable<Jewelry> All();
    }
}
