using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorbachev_KURS.Model
{
    public partial class DBEntities : DbContext
    {
        private static DBEntities context;

        public object User { get; internal set; }
        public object Users { get; internal set; }

        public static DBEntities getcontex()
        {
            if(context == null)
            {
                context = new DBEntities();
            }

            return context;
        }
    }
}
