using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Gorbachev_KURS.Model;

namespace Gorbachev_KURS.ClassFolder
{
    public static class AppData
    {
        public static DBEntities db = new DBEntities();
    }
}
