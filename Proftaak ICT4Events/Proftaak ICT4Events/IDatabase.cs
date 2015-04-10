using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    interface IDatabase
    {
        void Get(T);
        void Add(T);
        void Edit(T);
        void Remove(T);

    }
}
