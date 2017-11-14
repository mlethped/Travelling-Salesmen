using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;
using SalesmenEntities.Comparer;
using System.Collections.ObjectModel;

namespace SalesmenEntities.Model
{
    public class District : IDistrict
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IList<IStore> Stores { get; private set; }
        public IList<ISalesman> Salesmen { get; private set; }

        public District(string name, IList<IStore> stores, IList<ISalesman> salesmen, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Stores = new List<IStore>(stores);
            Salesmen = new List<ISalesman>(GetSalesmenFromStores(salesmen));
        }

        private IList<ISalesman> GetSalesmenFromStores(IList<ISalesman> salesmen)
        {
            var tmpSalesmenList = salesmen;

            foreach(var store in Stores)
            {
                foreach(var salesman in store.Salesmen)
                {
                    tmpSalesmenList.Add(salesman);
                }
            }

            return tmpSalesmenList.Distinct(new SalesmanComparer()).ToList();
        }
    }
}
