using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW6.Model
{
    [Table(Name = "Countries")]
    internal class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Capital { get; set; }

        [Column]
        public long Population { get; set; }

        [Column]
        public double Area { get; set; }
    
        [Column]
        public string Continent { get; set; }
    }
}