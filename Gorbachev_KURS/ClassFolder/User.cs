using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorbachev_KURS.ClassFolder
{
    public class User
    {
        public int User_ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }


       
    }

    
}
