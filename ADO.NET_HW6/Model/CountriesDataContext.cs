using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW6.Model
{
    internal class CountriesDataContext : DataContext
    {
        public CountriesDataContext() : base(ConfigurationManager.ConnectionStrings["CountriesDb"].ConnectionString) { }

        public Table<Country> Countries => GetTable<Country>();
    }
}
