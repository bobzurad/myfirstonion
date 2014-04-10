using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Queries;
using Domain.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace Persistence.ModelPersistence
{
    public class JewelryPersistence : IJewelryRepository, IJewelryQueries
    {
        protected ISession DbSession { get; private set; }

        public JewelryPersistence(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            DbSession = session;
        }

        public IEnumerable<Jewelry> All()
        {
            return
                DbSession
                    .CreateCriteria<Jewelry>()
                    .Add(Restrictions.Like("Name", "B", MatchMode.Start))   //TODO: remove this filter
                    .List<Jewelry>();
        }

        public Jewelry GetById(int id)
        {
            return DbSession.Get<Jewelry>(id);
        }
    }
}
