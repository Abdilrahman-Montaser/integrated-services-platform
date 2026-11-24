using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class LotRepository : GenericRepository<Lot>, ILotRepository
    {
        public LotRepository(TadweerHubDbContext context) : base(context)
        {
        }
        public IReadOnlyList<LotImage> GetByLotId(int lotId)
        {
            return context.Set<LotImage>()
                .AsNoTracking()
                .Where(i => i.LotId == lotId)
                .OrderBy(i => i.SortOrder)
                .ToList();
        }

        public LotImage? GetPrimaryByLotId(int lotId)
        {
            return context.Set<LotImage>()
                .AsNoTracking()
                .FirstOrDefault(i => i.LotId == lotId && i.IsPrimary);
        }

        public int CountByLotId(int lotId)
        {
            return context.Set<LotImage>().Count(i => i.LotId == lotId);
        }

        public void AddRange(IEnumerable<LotImage> images)
        {
            context.Set<LotImage>().AddRange(images);
        }

        public void SetPrimary(int lotId, int imageId)
        {
            var images = context.Set<LotImage>()
                .Where(i => i.LotId == lotId)
                .ToList();

            var target = images.FirstOrDefault(i => i.ImageId == imageId)
                ?? throw new KeyNotFoundException(
                    $"Image {imageId} not found for lot {lotId}.");

            if (target.IsPrimary)
                return;
            using var transaction = context.Database.BeginTransaction();

            foreach (var img in images.Where(i => i.IsPrimary))
                img.IsPrimary = false;
            context.SaveChanges();

            target.IsPrimary = true;
            context.SaveChanges();

            transaction.Commit();
        }
    }
}
