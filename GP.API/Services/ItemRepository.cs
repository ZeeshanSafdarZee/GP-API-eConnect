using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Services
{
    public class ItemRepository : IItemRepository
    {
        private GPContext _context;

        public ItemRepository(GPContext context)
        {
            _context = context;
        }

        public bool ItemExists(string ItemNumber)
        {
            return _context.ItemEntity.Any(c => c.Itemnmbr == ItemNumber);
        }

        public IEnumerable<ItemEntity> GetItems()
        {
            return _context.ItemEntity.OrderBy(c => c.Itemnmbr);
        }
        
        public ItemEntity GetItem(string ItemNumber)
        {
            return _context.ItemEntity.Where(c => c.Itemnmbr == ItemNumber).FirstOrDefault();
        }
                
        public ItemSiteEntity GetItemSite(string ItemNumber, string SiteID)
        {
            return _context.ItemSiteEntity.Where(c => c.Itemnmbr == ItemNumber && c.Locncode == SiteID).FirstOrDefault();
        }

        public ItemEntity GetItemWithSites(string ItemNumber)
        {
            return _context.ItemEntity.Include(c => c.ItemSites)
                .Where(c => c.Itemnmbr == ItemNumber).FirstOrDefault();
        }
                
    }
}
