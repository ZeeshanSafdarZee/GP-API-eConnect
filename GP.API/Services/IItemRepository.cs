using GP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Services
{
    public interface IItemRepository
    {
        bool ItemExists(string ItemNumber);
        IEnumerable<ItemEntity> GetItems();
        ItemEntity GetItem(string ItemNumber);
        ItemEntity GetItemWithSites(string ItemNumber);
        ItemSiteEntity GetItemSite(string ItemNumber, string SiteID);
    }
}
