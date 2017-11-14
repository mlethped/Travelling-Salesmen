using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmenEntities.Interface
{
    public interface IStore
    {
        Guid Id { get; }
        string Name { get; }
        IList<ISalesman> Salesmen { get; }
    }
}
