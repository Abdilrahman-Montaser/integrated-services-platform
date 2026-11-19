using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    internal interface IWalletTransactionRepository
    {
        WalletTransaction? GetById(int transactionId);
        IEnumerable<WalletTransaction> GetByWalletId(int walletId);
        void Add(WalletTransaction transaction);
        void Save();
    }
}