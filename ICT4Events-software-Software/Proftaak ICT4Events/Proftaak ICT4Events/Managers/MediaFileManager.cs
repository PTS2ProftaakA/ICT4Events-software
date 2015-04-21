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

        public List<MediaFile> GenerateFromPath()
        {
            return null;
        }

        public void NewFile(MediaFile file)
        {

        }

        public void DeleteFile(MediaFile file)
        {

        }

        public void EditFile(MediaFile file)
        {
            Rating rating = new Rating(CurrentUser.currentUser.propertyRFID, file.FilePath, 1, -1, true);
            file.Ratings.Add(rating);
        }

        public void testComment(Comment comment)
        {
            comment.Remove(comment, database);
        }
    }
}
