using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmanDataAccessLayer.Interface;
using SalesmanDataAccessLayer.Model;
using SalesmanDataAccessLayer.Queries;
using SalesmenEntities.Interface;
using SalesmenEntities.Model;
using System.Data.SqlClient;
using SalesmanDataAccessLayer.Utility;

namespace SalesmanDataAccessLayer.Adapter
{
    public class SalesmenAdapter : ISalesmenAdapter
    {
        private const string _sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Code\DB\SalesmenDatabase.mdf;Integrated Security=True"; 

        private const string _sqlCommandGetAllSalesmen = "SELECT * FROM Salesmen";

        public IList<IDistrict> RetrieveDataFromDatabase()
        {
            var districts = DBDistrictConverter.ConvertDBDistrict(GetDistrictDataFromDatabase(), GetStoreDataFromDatabase());

            return districts;
        }

        private IList<IStore> GetAllStores()
        {
            return null;
        }

        private IList<DBStore> GetStoreDataFromDatabase()
        {
            var tmpList = new List<DBStore>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch(Exception)
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }

                using (SqlCommand command = new SqlCommand(SqlQueries.GetStoresAndBelongingSalesmen, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Guid storeId = ObjectToGuid(reader[0]).Value;
                        string storeName = reader[1].ToString();
                        Guid districtId = ObjectToGuid(reader[2]).Value;
                        Guid? salesmanId = ObjectToGuid(reader[3]);
                        string salesmanName = reader[4].ToString();

                        tmpList.Add(new DBStore
                        {
                            Id = storeId,
                            Name = storeName,
                            DistrictId = districtId,
                            Salesman = salesmanId != null ? new DBSalesman { Id = salesmanId.Value, Name = salesmanName } : null
                        });
                    }
                }

                try
                {
                    connection.Close();
                }
                catch
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }

                return tmpList;
            }
        }

        private IList<DBDistrict> GetDistrictDataFromDatabase()
        {
            var tmpList = new List<DBDistrict>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }

                using (SqlCommand command = new SqlCommand(SqlQueries.GetDistrictsAndPrimarySalesmen, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Guid districtId = ObjectToGuid(reader[0]).Value;
                        string districtName = reader[1].ToString();
                        Guid primarySalesmanId = ObjectToGuid(reader[2]).Value;
                        string primarySalesmanName = reader[3].ToString();

                        tmpList.Add(new DBDistrict
                        {
                            Id = districtId,
                            Name = districtName,
                            PrimarySalesman = primarySalesmanId != null,
                            Salesman = new DBSalesman { Id = primarySalesmanId, Name = primarySalesmanName }
                        });
                    }
                }

                try
                {
                    connection.Close();
                }
                catch
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }
            }

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }

                using (SqlCommand command = new SqlCommand(SqlQueries.GetDistrictsAndBelongingSalesmen, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Guid districtId = ObjectToGuid(reader[0]).Value;
                        string districtName = reader[1].ToString();
                        Guid salesmanId = ObjectToGuid(reader[2]).Value;
                        string salesmanName = reader[3].ToString();

                        tmpList.Add(new DBDistrict
                        {
                            Id = districtId,
                            Name = districtName,
                            Salesman = new DBSalesman { Id = salesmanId, Name = salesmanName }
                        });
                    }
                }

                try
                {
                    connection.Close();
                }
                catch
                {
                    //ToDo: Error Handling, Log + Warning (use enum)
                }
            }

            return tmpList;

        }
        
        private Guid? ObjectToGuid(object obj)
        {
            if(obj == null)
            {
                return null;
            }

            return new Guid(obj.ToString());
        }
    }
}
