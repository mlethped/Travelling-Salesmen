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
    public static class DBStoreConverter
    {
        public static IList<IStore> ConvertDBStore(IList<DBStore> dbStores)
        {
            var tmpList = new List<IStore>();
            var storeConverted = false;

            foreach (var dbStore in dbStores)
            {
                storeConverted = false;
                var tmpSalesman = ConvertDBSalesman(dbStore.Salesman);

                storeConverted = ManageDublicateStoreEntriesFromDatabase(tmpList, storeConverted, dbStore, tmpSalesman);

                if (!storeConverted)
                {
                    AddStoreToTempList(tmpList, dbStore, tmpSalesman);
                }
            }

            return tmpList;
        }

        /// <summary>
        /// Since the Query <see cref="SqlQueries.GetStoresAndBelongingSalesmen"></see> may return multiple rows for each store
        /// It needs to ignore the store itself and only add the salesman to the existing entry in this case
        /// </summary>
        private static bool ManageDublicateStoreEntriesFromDatabase(List<IStore> tmpList, bool storeConverted, DBStore dbStore, ISalesman tmpSalesman)
        {
            foreach (var store in tmpList)
            {
                if (store.Id == dbStore.Id)
                {
                    storeConverted = true;

                    if (tmpSalesman != null)
                    {
                        if(store.Salesmen.Any(x => x.Id == tmpSalesman.Id))
                        {
                            store.Salesmen.Add(tmpSalesman);
                            break;
                        }
                    }
                }
            }

            return storeConverted;
        }

        private static void AddStoreToTempList(List<IStore> tmpList, DBStore dbStore, ISalesman tmpSalesman)
        {
            tmpList.Add(new Store(
                                    dbStore.Name,
                                    tmpSalesman != null ? new List<ISalesman>() { tmpSalesman } : new List<ISalesman>(),
                                    dbStore.Id));
        }

        private static ISalesman ConvertDBSalesman(DBSalesman salesman)
        {
            return salesman != null ? new Salesman(salesman.Name, salesman.Id) : null;
        }
    }
}
