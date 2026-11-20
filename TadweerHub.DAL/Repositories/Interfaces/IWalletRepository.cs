using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    internal interface IWalletRepository
    {
        Wallet? GetById(int walletId);
        Wallet? GetByUserId(int userId);
        void Add(Wallet wallet);
        void Update(Wallet wallet);
        void Save();
    }
}
