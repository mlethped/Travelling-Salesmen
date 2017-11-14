using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanDataAccessLayer.Model
{
    public class DBStore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DistrictId { get; set; }
        public DBSalesman Salesman { get; set; }
    }
}
