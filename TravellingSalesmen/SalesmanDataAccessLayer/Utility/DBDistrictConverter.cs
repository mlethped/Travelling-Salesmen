using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;
using SalesmenEntities.Model;
using SalesmanDataAccessLayer.Model;

namespace SalesmanDataAccessLayer.Utility
{
    public static class DBDistrictConverter
    {
        public static IList<IDistrict> ConvertDBDistrict(IList<DBDistrict> dbDistricts, IList<DBStore> dbStores)
        {
            var tmpList = new List<IDistrict>();
            var districtConverted = false;

            foreach (var dbDistrict in dbDistricts)
            {
                districtConverted = false;

                var tmpSalesman = ConvertDBSalesman(dbDistrict.Salesman, dbDistrict.PrimarySalesman);

                foreach (var district in tmpList)
                {
                    if (district.Id == dbDistrict.Id)
                    {
                        districtConverted = true;

                        if (tmpSalesman != null)
                        {
                            if (!district.Salesmen.Any(x => x.Id == tmpSalesman.Id))
                            {
                                district.Salesmen.Add(tmpSalesman);
                                break;
                            }
                        }
                    }
                }

                if (!districtConverted)
                {
                    var tmpStores = dbStores.Where(x => x.DistrictId == dbDistrict.Id);
                    var stores = DBStoreConverter.ConvertDBStore(tmpStores.ToList());

                    tmpList.Add(new District(
                                    dbDistrict.Name,
                                    stores,
                                    tmpSalesman != null ? new List<ISalesman>() { tmpSalesman } : new List<ISalesman>(),
                                    dbDistrict.Id));
                }
            }

            return tmpList;
        }

        /// <summary>
        /// Since the Query <see cref="SqlQueries.GetStoresAndBelongingSalesmen"></see> may return multiple rows for each store
        /// It needs to ignore the store itself and only add the salesman to the existing entry in this case
        /// </summary>

        private static ISalesman ConvertDBSalesman(DBSalesman salesman, bool primarySalesman)
        {
            return salesman != null ? new Salesman(salesman.Name, salesman.Id, primarySalesman) : null;
        }
    }
}
