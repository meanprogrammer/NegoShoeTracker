using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class DbContextBase
    {
        public Database db { get; set; }
        public DbContextBase()
        {
            db = DatabaseFactory.CreateDatabase();
        }
    }
}
