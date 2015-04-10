using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    interface IDatabase
    {
        void Get(Type type);

        void Add(Type type);

        void Edit(Type type);

        void Remove(Type type);
    }
}
