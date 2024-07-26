using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class OutwardRepository : IOutwardRepository
    {
        private readonly SimplePOSContext _context;

        public OutwardRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<Outward> GetAllOutwards()
        {
            return _context.Outwards
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .ToList();
        }

        public Outward GetOutwardById(int id)
        {
            return _context.Outwards
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OutwardId == id);
        }

        public void CreateOutward(Outward outward)
        {
            _context.Outwards.Add(outward);
            _context.SaveChanges();
        }
    }
}
