using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Class
{
    internal class WalletTransactionRepository
        : IWalletTransactionRepository
    {
        private readonly TadweerHubDbContext _context;
        public WalletTransactionRepository(TadweerHubDbContext context)
        {
            _context = context;
        }
        public WalletTransaction? GetById(int transactionId)
        {
            return _context.Set<WalletTransaction>()
                .FirstOrDefault(t => t.TransactionId == transactionId);
        }
        public IEnumerable<WalletTransaction> GetByWalletId(int walletId)
        {
            return _context.Set<WalletTransaction>()
                .Where(t => t.WalletId == walletId)
                .ToList();
        }
        public void Add(WalletTransaction transaction)
        {
            _context.Set<WalletTransaction>().Add(transaction);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
