using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class LotRepository : GenericRepository<Lot>, ILotRepository
    {
        public LotRepository(TadweerHubDbContext context) : base(context)
        {
        }
    }
}
