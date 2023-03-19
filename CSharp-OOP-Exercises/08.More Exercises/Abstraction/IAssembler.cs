using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IAssembler
    {
        decimal SumPrice(IEnumerable<ComputerComponent> components);
        void PartsOrder(int partsOrdered);
        void AddVAT();
    }
}
