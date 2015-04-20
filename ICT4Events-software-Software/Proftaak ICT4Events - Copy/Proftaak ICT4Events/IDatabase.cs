using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    interface IDatabase<T> where T : class
    {
        T Get(string identifier, Database database);

        void Add(T type, Database database);

        void Edit(T type, Database database);

        void Remove(T type, Database database);
    }
}
