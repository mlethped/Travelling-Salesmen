using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmenEntities.Interface
{
    public interface ISalesman
    {
        Guid Id { get; }
        string Name { get; }
        bool PrimarySalesman { get; }
    }
}
