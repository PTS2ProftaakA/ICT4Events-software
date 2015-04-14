using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class FeedManager
    {
        FeedManager()
        {
            
        }

        public List<MediaFile> GetFiles(string specification, Database database)
        {
            return MediaFile.GetFiles(specification, database);
        }

        public List<MediaFile> GetPopular()
        {
            return null;
        }

        public List<MediaFile> Search(string text)
        {
            return null;
        }
    }
}
