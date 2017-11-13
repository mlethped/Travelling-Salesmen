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
        public IReadOnlyCollection<IStore> Stores { get; private set; }
        public IReadOnlyCollection<ISalesman> Salesmen { get; private set; }

        public District(string name, IList<IStore> stores, IList<ISalesman> salesmen)
        {
            Id = Guid.NewGuid();
            Name = name;
            Stores = new ReadOnlyCollection<IStore>(stores);
            Salesmen = new ReadOnlyCollection<ISalesman>(GetSalesmenFromStores(salesmen));
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
