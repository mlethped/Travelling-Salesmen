using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanDataAccessLayer.Queries
{
    public static class SqlQueries
    {
        public static string GetDistrictsAndPrimarySalesmen =
            "SELECT d.Id, d.Name, d.PrimarySalesman, s.Name " +
            "FROM Districts d " +
            "LEFT JOIN Salesmen s " +
            "ON d.PrimarySalesman = s.Id";

        public static string GetDistrictsAndBelongingSalesmen = 
            "SELECT d.Id, d.Name, ds.SalesmanId, s.Name " +
            "FROM Districts d " +
            "INNER JOIN DistrictsAndSalesmen ds " +
            "ON d.Id = ds.DistrictId " +
            "LEFT JOIN Salesmen s " +
            "ON ds.SalesmanId = s.Id";

        public static string GetStoresAndBelongingSalesmen =
            "SELECT st.Id, st.Name, st.DistrictId, ss.SalesmanId, sa.Name " +
            "FROM Stores st " +
            "LEFT JOIN Districts d " +
            "ON st.DistrictId = d.Id " +
            "LEFT JOIN StoresAndSalesmen ss " +
            "ON st.Id = ss.StoreId " +
            "LEFT JOIN Salesmen sa " +
            "ON ss.SalesmanId = sa.Id";
    }
}
