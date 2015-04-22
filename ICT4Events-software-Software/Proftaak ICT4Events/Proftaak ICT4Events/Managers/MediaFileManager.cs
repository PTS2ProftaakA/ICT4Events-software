using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class MediaFileManager
    {
        Database database;

        public MediaFileManager(Database database) 
        {
            this.database = database;
        }

        //Not yet implemented
        public List<MediaFile> GenerateFromPath()
        {
            return null;
        }

        //Not yet implemented
        public void NewFile(MediaFile file)
        {

        }

        //Not yet implemented
        public void DeleteFile(MediaFile file)
        {

        }

        //Edits a file in the database using the Edit function in MediaFile
        public void EditFile(MediaFile file)
        {
            //Rating rating = new Rating(CurrentUser.currentUser.propertyRFID, file.FilePath, 1, -1, true);
            //file.Ratings.Add(rating);
        }
    }
}
