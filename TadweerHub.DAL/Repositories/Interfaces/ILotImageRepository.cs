using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface ILotImageRepository : IGenericRepository<LotImage>
    {
        IReadOnlyList<LotImage> GetByLotId(int lotId);
        LotImage? GetPrimaryByLotId(int lotId);
        int CountByLotId(int lotId);
        void AddRange(IEnumerable<LotImage> images);
        void SetPrimary(int lotId, int imageId);
    }
}
