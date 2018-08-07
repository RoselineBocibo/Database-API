using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAPI
{
    public interface IDBWrapper<I>
    {
        IEnumerable<I> Select(I entity);
        int CreatEntity(I entity);
        int Update(I entity);
        int Delete(I entity);
    }
}
