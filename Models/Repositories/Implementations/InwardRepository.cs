using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class InwardRepository : IInwardRepository
    {
        private readonly SimplePOSContext _context;

        public InwardRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<Inward> AllInwards
        {
            get
            {
                return _context.Inwards
                    .Include(i => i.InwardProducts)
                        .ThenInclude(ip => ip.Product)
                    .Include(i => i.Supplier)
                    .OrderByDescending(i => i.Date);
            }
        }

        public Inward? GetInwardById(int id)
        {
            return _context.Inwards
                .Include(i => i.InwardProducts)
                    .ThenInclude(ip => ip.Product)
                .Include(i => i.Supplier)
                .FirstOrDefault(i => i.InwardId == id);
        }

        public void AddInward(Inward inward)
        {
            try
            {
                _context.Inwards.Add(inward);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the inward transaction.", ex);
            }
        }


        public void UpdateInward(Inward inward)
        {
            try
            {
                _context.Inwards.Update(inward);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the inward transaction.", ex);
            }
        }

        public void DeleteInward(int id)
        {
            var inward = _context.Inwards.Find(id);
            if (inward != null)
            {
                _context.Inwards.Remove(inward);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
