using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;

namespace SalesmenEntities.Comparer
{
    public class SalesmanComparer : EqualityComparer<ISalesman>
    {
        public override bool Equals(ISalesman x, ISalesman y)
        {
            return x.Id == y.Id;
        }

        public override int GetHashCode(ISalesman obj)
        {
            return 0;
        }
    }
}
