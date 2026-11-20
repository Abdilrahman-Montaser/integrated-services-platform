using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IWalletTransactionRepository : IGenericRepository<WalletTransaction>
    {
        IEnumerable<WalletTransaction> GetByWalletId(int walletId);
    }
}