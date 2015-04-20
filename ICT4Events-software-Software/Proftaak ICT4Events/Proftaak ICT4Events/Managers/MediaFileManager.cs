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

        }

        public void testComment(Comment comment)
        {
            comment.Remove(comment, database);
        }
    }
}
