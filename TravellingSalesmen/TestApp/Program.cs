using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmanDataAccessLayer.Adapter;
using SalesmenEntities;
using SalesmenFunctions;
using SalesmenPresentation;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
                        var adapter = new SalesmenAdapter();
            adapter.RetrieveDataFromDatabase();           
        }
    }
}
