using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(TadweerHubDbContext context) : base(context)
        {
        }
        public Wallet? GetByUserId(int userId)
        {
            return context.Set<Wallet>()
                .FirstOrDefault(w => w.UserId == userId);
        }
    }
}