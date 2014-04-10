using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Queries;
using Domain.Repositories;

namespace Persistence.Fake.ModelPersistence
{
    public class JewelryPersistence : IJewelryRepository, IJewelryQueries
    {
        public IEnumerable<Jewelry> All()
        {
            return
                new List<Jewelry> {
                    new Jewelry { Name = "BCB", ImageFileName = "BCB.jpg", Quantity = 1 },
                    new Jewelry { Name = "BCM Bracelet", ImageFileName = "BCMBracelet.jpg", Quantity = 1 },
                    new Jewelry { Name = "Black Grey Braided Bracelet", ImageFileName = "BlackGreyBraidedBracelet.jpg", Quantity = 1 },
                    new Jewelry { Name = "Blue Yellow BCB", ImageFileName = "BlueYellowBCB.jpg", Quantity = 1 },
                    new Jewelry { Name = "Coasters", ImageFileName = "Coasters.jpg", Quantity = 1 },
                    new Jewelry { Name = "Crystal Earings", ImageFileName = "CrystalEarings.jpg", Quantity = 1 },
                    new Jewelry { Name = "CSCM Pendant", ImageFileName = "CSCMPendant.jpg", Quantity = 1 },
                    new Jewelry { Name = "CSC Pendant", ImageFileName = "CSCPendant.jpg", Quantity = 1 },
                    new Jewelry { Name = "Earrings", ImageFileName = "Earrings.jpg", Quantity = 1 },
                    new Jewelry { Name = "Red Celtic Star Pendant", ImageFileName = "RedCelticStarPendant.jpg", Quantity = 1 },
                    new Jewelry { Name = "Silver Black Byzantine Bracelet", ImageFileName = "SilverBlackByzantineBracelet.jpg", Quantity = 1 }
                };
        }

        public Jewelry GetById(int id)
        {
            return All().SingleOrDefault(j => j.Id == id);
        }
    }
}
