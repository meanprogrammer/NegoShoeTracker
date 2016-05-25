using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class DbContextBase
    {
        protected NegoShoeDbDataContext context = null;
        public DbContextBase()
        {
            context = new NegoShoeDbDataContext();
        }
    }
}
