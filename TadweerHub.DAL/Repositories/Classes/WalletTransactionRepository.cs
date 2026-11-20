using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class WalletTransactionRepository : GenericRepository<WalletTransaction>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(TadweerHubDbContext context) : base(context)
        {
        }
        public IEnumerable<WalletTransaction> GetByWalletId(int walletId)
        {
            return context.Set<WalletTransaction>()
                .Where(t => t.WalletId == walletId)
                .ToList();
        }
    }
}
