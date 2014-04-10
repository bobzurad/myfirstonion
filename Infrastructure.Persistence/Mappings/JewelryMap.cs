using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infrastructure.Persistence.Mappings
{
    public class JewelryMap : ClassMap<Jewelry>
    {
        public JewelryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ImageFileName);
            Map(x => x.Quantity);
        }
    }
}
