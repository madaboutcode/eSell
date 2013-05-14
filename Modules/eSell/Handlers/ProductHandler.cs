using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using eSell.Models;

namespace eSell.Handlers
{
    public class ProductHandler:ContentHandler
    {
        public ProductHandler(IRepository<ProductPartRecord> repository) 
        {
            Filters.Add(StorageFilter.For(repository));    
        }
    }
}