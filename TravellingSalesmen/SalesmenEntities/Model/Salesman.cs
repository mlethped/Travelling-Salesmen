using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;

namespace SalesmenEntities.Model
{
    public class Salesman : ISalesman
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool PrimarySalesman { get; }

        public Salesman(string name, Guid? id = null, bool primarySalesman = false)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            PrimarySalesman = primarySalesman;
        }
    }
}
