using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;

namespace SalesmanDataAccessLayer.Interface
{
    public interface ISalesmenAdapter
    {
        IList<IDistrict> RetrieveDataFromDatabase();
    }
}
