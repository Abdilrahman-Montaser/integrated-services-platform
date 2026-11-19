using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Class
{
    internal class WalletRepository : IWalletRepository
    {
        private readonly TadweerHubDbContext _context;
        public WalletRepository(TadweerHubDbContext context)
        {
            _context = context;
        }
        public Wallet? GetById(int walletId)
        {
            return _context.Set<Wallet>()
                .FirstOrDefault(w => w.WalletId == walletId);
        }
       public Wallet? GetByUserId(int userId)
        {
            return _context.Set<Wallet>()
                .FirstOrDefault(w => w.UserId == userId);
        }
        public void Add(Wallet wallet)
        {
            _context.Set<Wallet>().Add(wallet);
        }
        public void Update(Wallet wallet)
        {
            _context.Set<Wallet>().Update(wallet);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}