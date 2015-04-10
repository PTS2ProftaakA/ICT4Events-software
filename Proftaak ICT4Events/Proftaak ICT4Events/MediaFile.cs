using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum FileType
    {
        Image,
        Video,
        Text,
        Music
    };

    class MediaFile
    {
        private string filePath;
        private string comment;

        private FileType type;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public FileType Type
        {
            get { return type; }
            set { type = value; }
        }


        public MediaFile(string filePath, FileType type, string comment)
        {
            this.filePath = filePath;
            this.type = type;
            this.comment = comment;
        }

        public MediaFile GetAll() 
        {
            return null;
        }
    }
}
