using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmenEntities.Interface
{
    public interface IDistrict
    {
        Guid Id { get; }
        string Name { get; }
        IReadOnlyCollection<IStore> Stores { get; }
        IReadOnlyCollection<ISalesman> Salesmen { get; }
    }
}
