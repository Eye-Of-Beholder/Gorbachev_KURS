using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorbachev_KURS.ClassFolder
{
    internal class OrderClass
    {
        public int OrderID { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string Problem { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; } // Добавлено свойство Phone
        public string Email { get; set; }
    }
}
