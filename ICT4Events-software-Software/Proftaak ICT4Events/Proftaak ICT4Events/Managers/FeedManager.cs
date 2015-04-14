using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class FeedManager
    {
        Database database;

        FeedManager()
        {
            database = new Database();
        }

        public List<MediaFile> GetFiles(string specification, Database database)
        {
            return MediaFile.GetFiles(specification, database);
        }

    }
}
