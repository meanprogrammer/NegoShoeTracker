﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class ItemStatusDA : DbContextBase
    {
        public List<ItemStatus> GetAllItemStatus()
        {
            return this.context.ItemStatus.ToList();
        }
    }
}