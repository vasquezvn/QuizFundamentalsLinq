using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLinq
{
    public class MyDbCars : DbContext
    {
        public DbSet<Car> MyTableCars { get; set; }
    }
}
