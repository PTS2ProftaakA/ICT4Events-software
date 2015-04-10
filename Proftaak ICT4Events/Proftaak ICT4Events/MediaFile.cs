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


        private FileType type;
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public string FilePath

        {
            get { return filePath; }
            set { filePath = value; }
        }

        public MediaFile(string FilePath, FileType Type, string Comment)
        {
            this.FilePath = FilePath;
            this.type = Type;
            this.Comment = Comment;
        }

        public MediaFile GetAll() 
        {
            return this;
        }
    }
}
