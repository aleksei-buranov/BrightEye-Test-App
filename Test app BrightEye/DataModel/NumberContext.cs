using System;
using System.Data.Entity;
using System.Linq;

namespace Test_app_BrightEye.DataModel
{
    public class NumberContext : DbContext
    {
        public NumberContext()
            : base("name=NumberContext")
        {
        }

        public DbSet<Number> Numbers { get; set; }
        public DbSet<SortNumber> SortNumbers { get; set; }
    }
}