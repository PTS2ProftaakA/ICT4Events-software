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
        Comment comment;

        public MediaFileManager() 
        {
            database = new Database();
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
            comment.Edit(comment, database);
        }
    }
}
