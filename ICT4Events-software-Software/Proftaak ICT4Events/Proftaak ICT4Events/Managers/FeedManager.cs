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

        public FeedManager(Database database)
        {
            this.database = database;
        }

        public List<MediaFile> GetFiles(string specification, Database database)
        {
            return MediaFile.GetFiles(specification, database);
        }
        public List<MediaType> getTypes(Database database)
        {
            return MediaType.GetAll(database);
        }
        public void makePost(MediaType type, string description, string filePath)
        {
            MediaFile newmedia = new MediaFile(filePath, description, CurrentUser.currentUser.propertyRFID, database.nextSequenceValue("MEDIABESTANDSEQUENCE"), CurrentUser.currentUser.EventID, DateTime.Now, type);
            newmedia.Add(newmedia, database);
        }

    }
}
