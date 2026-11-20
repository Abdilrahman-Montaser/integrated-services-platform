using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class LotImageRepository : GenericRepository<LotImage>, ILotImageRepository
    {
        public LotImageRepository(TadweerHubDbContext context) : base(context)
        {
        }
    }
}
