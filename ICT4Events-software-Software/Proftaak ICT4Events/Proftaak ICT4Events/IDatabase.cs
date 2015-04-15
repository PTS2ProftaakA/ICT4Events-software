using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    interface IDatabase
    {
        T Get<T>(string identifier, Database database);

        void Add<T>(T type, Database database);

        void Edit<T>(T type, Database database);

        void Remove<T>(T type, Database database);
    }
}
