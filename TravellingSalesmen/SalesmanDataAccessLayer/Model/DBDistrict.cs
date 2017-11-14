using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanDataAccessLayer.Model
{
    public class DBDistrict
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool PrimarySalesman { get; set; }
        public DBSalesman Salesman { get; set; }
    }
}
